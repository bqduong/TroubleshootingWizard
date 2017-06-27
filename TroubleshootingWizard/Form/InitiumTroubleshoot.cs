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
        private Tree<Node> _instructionTree;
        private TreeUtility _treeUtility;
        private ITreeNode<Node> _currentNode;
        private bool _testResult;
        private string _outPutDirectory;
        private string _radioOptionValue;
        private WizardUIService _troubleshootingWizardUiService;
        private readonly string _pdfReader = @"C:\ProgramData\InitiumGui\help\SumatraPDF.exe";
        private readonly string _pdfPath = @"C:\ProgramData\InitiumGui\help\904001.2-VROC initium Manual.pdf";
        private readonly string _emptyString = "";
        private readonly string _pdfLinkText = "Open Initium Manual (PDF)";
        private readonly string _finishText = "Finish";
        private readonly string _nextText = "Next";
        private readonly string _cancelText = "Cancel";
        private readonly string _noneText = "none";
        private readonly string _trueText = "true";
        private readonly string _testSyringe = "Syringe Assembly";
        private readonly string _ip = "Plunger";
        private readonly char _splitChar = ',';

        public InitiumTroubleshoot()
        {
            InitializeComponent();
        }

        public InitiumTroubleshoot(string filePath)
        {
            this.InitializeComponent();
            this.InitializeData(filePath);
        }

        private bool IsFinish => this.wizardControl.FinishButtonText != this._finishText;

        private void InitializeData(string filePath)
        {
            this._treeUtility = new TreeUtility();
            this._troubleshootingWizardUiService = new WizardUIService();
            this._instructionTree = _treeUtility.BuildTree(filePath);
            if (this._instructionTree != null)
            {
                this._currentNode = _instructionTree.Root;
                this._testResult = true;
                this._outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }

            this.ToggleYesNoState(false);
        }

        private void wizardControl_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                if ((e as AeroWizard.SelectedPageEventArgs) != null)
                {
                    if ((e as AeroWizard.SelectedPageEventArgs).IsPrevious)
                    {
                        this._currentNode = this._treeUtility.TraveseUpTree(this._currentNode);
                        this.UpdateUIDependencies(this._currentNode, true);
                        this.ExecuteInitiumFunctions(this._currentNode);
                    }
                }
                else
                {
                    if (this.IsFinish)
                    {
                        this._currentNode = this._treeUtility.TraverseDownTree(this._currentNode, this._testResult);
                        this.UpdateUIDependencies(this._currentNode, false);
                        this.ExecuteInitiumFunctions(this._currentNode);
                        this.wizardPage.AllowBack = false;
                    }
                    else
                    {
                        Close();
                    }
                }
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

        private void wizardControl_SelectedPageChanged2(object sender, EventArgs e)
        {
            this._testResult = false;
            this._currentNode = this._treeUtility.TraverseDownTree(this._currentNode, this._testResult);
            this.UpdateUIDependencies(this._currentNode, false);
            this.ExecuteInitiumFunctions(this._currentNode);
            try
            {
                this.LoadMedia(this._currentNode);
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

        private void wizardControl_enableNext(object sender, EventArgs e)
        {
            this.wizardPage.AllowNext = true;
            this._radioOptionValue = (sender as RadioButton).Text;
        }
        
        private void wizardControl_executeBackgroundFunction(object sender, EventArgs e)
        {
            this._troubleshootingWizardUiService.RunDiagHelperMethod(
                (Wizard.Enums.DIAG_HELPER_METHODS)Enum.Parse(typeof(Wizard.Enums.DIAG_HELPER_METHODS), 
                                                                    this._currentNode.Value.ActionCode));
        }

        private void wizardControl_loadManualClicked(object sender, System.EventArgs e)
        {
            var pageNumber = this._currentNode.Value.PageNumber;
            System.Diagnostics.Process.Start(this._pdfReader, @"-page " + pageNumber + " \"" + this._pdfPath + "\"");
        }

        private void InitiumTroubleshoot_Load(object sender, EventArgs e)
        {

        }

        private void LoadMedia(ITreeNode<Node> node)
        {
            this.TryLoadImage(node);
            this.TryLoadVideo(node);
            this.TryLoadPdf(node);
        }

        private void TryLoadImage(ITreeNode<Node> node)
        {
            if (node.Value.ImageLink != this._emptyString)
            {
                var imageURL = Path.Combine(this._outPutDirectory, node.Value.ImageLink);
                this.troubleshootImage.ImageLocation = imageURL;
                this.troubleshootImage.Visible = true;
            }
            else
            {
                this.troubleshootImage.Visible = false;
            }
        }

        private void TryLoadVideo(ITreeNode<Node> node)
        {
            if (node.Value.VideoLink != this._emptyString)
            {
                var videoURL = Path.Combine(this._outPutDirectory, node.Value.VideoLink);
                this.axWindowsMediaPlayer.URL = videoURL;
                this.axWindowsMediaPlayer.Visible = true;
                this.axWindowsMediaPlayer.uiMode = this._noneText;
            }
            else
            {
                this.axWindowsMediaPlayer.Visible = false;
            }
        }

        private void TryLoadPdf(ITreeNode<Node> node)
        {
            this.wizardPage.HelpText = node.Value.PdfLink != null ? _pdfLinkText : this._emptyString;
        }

        private void UpdateUIDependencies(ITreeNode<Node> node, bool isPrevious)
        {
            if (node == null) return;
            this.LoadMedia(node);
            this.UpdateYesNoUIDependencies(node, isPrevious);
            this.UpdateRadioButtonUIDependencies();
            this.UpdatePageText();
        }

        private void UpdateRadioButtonUIDependencies()
        {
            if (this._currentNode.Value.Selectable != null)
            {
                this.wizardPage.AllowNext = false;
                var selectionValues = this._currentNode.Value.Selectable.Split(this._splitChar);
                this.ToggleRadioButtonVisibility(true);
                this.AssignLabelsToRadioButtons(selectionValues);
            }
            else
            {
                this.wizardPage.AllowNext = true;
                this.ToggleRadioButtonVisibility(false);
            }
        }

        private void AssignLabelsToRadioButtons(string[] selectionValues)
        {
            this.radioButton1.Text = selectionValues[0];
            this.radioButton2.Text = selectionValues[1];
        }

        private void UpdateYesNoUIDependencies(ITreeNode<Node> node, bool isPrevious)
        {
            if (this._currentNode.Value.IsYesNo == this._trueText || this._currentNode.Value.IsYesNo != null)
            {
                this.ToggleYesNoState(true);
            }
            else
            {
                this.ToggleYesNoState(false);
                this.UpdateButtonText(node, isPrevious);
            }
        }

        private void UpdatePageText()
        {
            this.wizardPage.Text = this._currentNode.Value.Header;
            this.description.Text = this._currentNode.Value.Description;
        }

        private void UpdateButtonText(ITreeNode<Node> node, bool isPrevious)
        {
            this.wizardControl.FinishButtonText = isPrevious
                ? this.wizardControl.FinishButtonText = this._nextText
                : !node.ChildNodes.Any()
                    ? this._finishText
                    : this._nextText;

            if (!node.ChildNodes.Any())
            {
                this.wizardPage.IsFinishPage = true;
            }
            this.wizardControl.CancelButtonText = this._cancelText;
        }

        private void ExecuteInitiumFunctions(ITreeNode<Node> node)
        {
            if (node != null)
            {
                var isExecuteProcess = Convert.ToBoolean(node.Value.IsExecuteProcess);
                if (isExecuteProcess)
                {
                    this.ToggleButtonState(false);
                    this.SetProgressBarVisisbility(true);

                    if (this._radioOptionValue != null)
                    {
                        if (this._radioOptionValue == this._testSyringe)
                        {
                            this._testResult = _troubleshootingWizardUiService.RunDiagHelperMethod(
                                (Wizard.Enums.DIAG_HELPER_METHODS)Enum.Parse(typeof(Wizard.Enums.DIAG_HELPER_METHODS),
                                    node.Value.ActionCode));
                        }
                        else
                        {
                            //IP replaced
                            this._testResult = _troubleshootingWizardUiService.RunDiagHelperMethod(
                                (Wizard.Enums.DIAG_HELPER_METHODS)Enum.Parse(typeof(Wizard.Enums.DIAG_HELPER_METHODS),
                                    node.Value.ActionCode));
                        }

                    }
                    else
                    {
                        if (Control.IsKeyLocked(Keys.CapsLock))
                        {
                            this._testResult = Control.ModifierKeys != Keys.Shift;
                        }
                        else
                        {
                            this._testResult = _troubleshootingWizardUiService.RunDiagHelperMethod(
                                (Wizard.Enums.DIAG_HELPER_METHODS) Enum.Parse(typeof(Wizard.Enums.DIAG_HELPER_METHODS),
                                    node.Value.ActionCode));
                        }
                    }

                    this.EnvokeNextPage();
                    this.ToggleButtonState(true);
                }
                else
                {
                    this.SetProgressBarVisisbility(false);
                    this._testResult = true;
                }
            }
        }

        private void EnvokeNextPage()
        {
            //this.wizardControl_SelectedPageChanged(null, null);
        }

        private void ToggleRadioButtonVisibility(bool isVisible)
        {
            this.radioButton1.Visible = isVisible;
            this.radioButton2.Visible = isVisible;
        }

        private void ToggleYesNoState(bool isYesNo)
        {
            this.wizardPage.ShowNo = isYesNo;
            this.wizardPage.ShowYes = isYesNo;
            this.wizardPage.ShowCancel = !isYesNo;
            this.wizardPage.ShowNext = !isYesNo;
        }

        private void ToggleButtonState(bool isEnabled)
        {
            if (isEnabled)
            {
                this.wizardPage.AllowCancel = false;
                this.wizardPage.AllowNext = isEnabled;
                this.wizardPage.AllowBack = isEnabled;
                this.wizardPage.AllowCancel = true;
            }
            else
            {
                this.wizardPage.AllowNext = isEnabled;
                this.wizardPage.AllowBack = isEnabled;
            }
        }

        private void SetProgressBarVisisbility(bool isVisible)
        {
            this.progressBar.Visible = isVisible;
        }
    }
}