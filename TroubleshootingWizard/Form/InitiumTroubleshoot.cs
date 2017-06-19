using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using AeroWizard;
using Wizard.Interfaces;
using Wizard.Models;
using Wizard.Services;
using Wizard.Utilities;

namespace TroubleshootingWizard
{
    public partial class InitiumTroubleshoot : Form
    {
        private Tree<Node> instructionTree;
        private TreeUtility treeUtility;
        private ITreeNode<Node> currentNode;
        private bool testResult;
        private string outPutDirectory;
        private WizardUIService troubleshootingWizardUiService;

        public InitiumTroubleshoot()
        {
            InitializeComponent();
        }

        public InitiumTroubleshoot(string filePath)
        {
            this.InitializeComponent();
            this.InitializeData(filePath);
        }

        private void InitializeData(string filePath)
        {
            this.treeUtility = new TreeUtility();
            this.troubleshootingWizardUiService = new WizardUIService();
            this.instructionTree = treeUtility.BuildTree(filePath);
            if (this.instructionTree != null)
            {
                this.currentNode = instructionTree.Root;
                this.testResult = true;
                this.outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }

            this.wizardPage.ShowNo = false;
            this.wizardPage.ShowYes = false;
        }

        private void wizardControl_SelectedPageChanged(object sender, EventArgs e)
        {
            if ((e as AeroWizard.SelectedPageEventArgs) != null)
            {
                if ((e as AeroWizard.SelectedPageEventArgs).IsPrevious)
                {
                    this.currentNode = this.treeUtility.TraveseUpTree(this.currentNode);
                    this.UpdateUIDependencies(this.currentNode, true);
                }
            }
            else
            {
                if (this.wizardControl.FinishButtonText != "Finish")
                {
                    this.currentNode = this.treeUtility.TraverseDownTree(this.currentNode, this.testResult);
                    this.UpdateUIDependencies(this.currentNode, false);
                    this.testResult = this.ExecuteInitiumFunctions(this.currentNode);

                }
                else
                {
                    Close();
                }
            }
            try
            {
                this.LoadMedia(this.currentNode);
            }
            catch (Exception ex)
            {
                try
                {
                    Close();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }
        
        private void InitiumTroubleshoot_Load(object sender, EventArgs e)
        {

        }

        private void LoadMedia(ITreeNode<Node> node)
        {
            if (node.Value.ImageLink != "")
            {
                var imageURL = Path.Combine(this.outPutDirectory, node.Value.ImageLink);
                this.troubleshootImage.ImageLocation = imageURL;
                this.troubleshootImage.Visible = true;
            }
            else
            {
                this.troubleshootImage.Visible = false;
            }

            if (node.Value.VideoLink != "")
            {
                var videoURL = Path.Combine(this.outPutDirectory, node.Value.VideoLink);
                this.axWindowsMediaPlayer.URL = videoURL;
                this.axWindowsMediaPlayer.Visible = true;
                this.axWindowsMediaPlayer.uiMode = "none";
            }
            else
            {
                this.axWindowsMediaPlayer.Visible = false;
            }
        }

        private void UpdateUIDependencies(ITreeNode<Node> node, bool isPrevious)
        {
            if (node != null)
            {
                if (this.currentNode.Value.IsYesNo == "true" || this.currentNode.Value.IsYesNo != null)
                {
                    this.wizardPage.ShowNo = true;
                    this.wizardPage.ShowYes = true;
                    this.wizardPage.ShowCancel = false;
                    this.wizardPage.ShowNext = false;
                }
                else
                {
                    this.wizardPage.ShowNo = false;
                    this.wizardPage.ShowYes = false;
                    this.wizardPage.ShowCancel = true;
                    this.wizardPage.ShowNext = true;
                    if (isPrevious)
                    {
                        this.wizardControl.FinishButtonText = "Next";
                        this.wizardControl.CancelButtonText = "Cancel";
                    }
                    else
                    {
                        if (!node.ChildNodes.Any())
                        {
                            this.wizardControl.FinishButtonText = "Finish";
                        }
                        else
                        {
                            this.wizardControl.CancelButtonText = "Cancel";
                            this.wizardControl.FinishButtonText = "Next";
                        }
                    }
                }

                this.wizardPage.Text = this.currentNode.Value.Header;
                this.description.Text = this.currentNode.Value.Description;
            }
        }

        private bool ExecuteInitiumFunctions(ITreeNode<Node> node)
        {
            if (node != null)
            {
                var isExecuteProcess = Convert.ToBoolean(node.Value.IsExecuteProcess);
                this.SetProgressBarVisisbility(isExecuteProcess);

                if (isExecuteProcess)
                {
                    return troubleshootingWizardUiService.RunDiagHelperMethod(
                        (Wizard.Enums.DIAG_HELPER_METHODS)Enum.Parse(typeof(Wizard.Enums.DIAG_HELPER_METHODS), node.Value.ActionCode));
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        private void SetProgressBarVisisbility(bool isVisible)
        {
            this.progressBar.Visible = isVisible;
        }
    }
}