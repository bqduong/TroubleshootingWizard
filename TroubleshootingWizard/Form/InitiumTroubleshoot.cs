using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace TroubleshootingWizard
{
    public partial class InitiumTroubleshoot : Form
    {
        private Tree<Node> instructionTree;

        private ITreeNode<Node> currentNode;
        public InitiumTroubleshoot()
        {
            InitializeComponent();
            this.instructionTree = this.BuildTree();
            currentNode = null;
        }

        private void wizardControl_SelectedPageChanged(object sender, EventArgs e)
        {
            if ((e as AeroWizard.SelectedPageEventArgs) != null)
            {
                if ((e as AeroWizard.SelectedPageEventArgs).IsPrevious)
                {
                    currentNode = currentNode == null ? this.instructionTree.Root : currentNode.Parent as ITreeNode<Node>;
                    this.wizardControl.FinishButtonText = "Next";
                }
            }
            else
            {
                if (this.wizardControl.FinishButtonText != "Finish")
                {
                    currentNode = currentNode == null ? this.instructionTree.Root : currentNode.ChildNodes.First() as ITreeNode<Node>;
                    if (!currentNode.ChildNodes.Any())
                    {
                        this.wizardControl.FinishButtonText = "Finish";
                    }
                }
                else
                {
                    Close();
                }
            }

            this.wizardPage.Text = this.currentNode.Value.Header;
            this.description.Text = this.currentNode.Value.Description;

            if (this.currentNode.Value.IsExecuteProcess == "true")
            {
                this.progressBar1.Visible = true;
            }
            else
            {
                this.progressBar1.Visible = false;
            }


            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var logoimage = Path.Combine(outPutDirectory, this.currentNode.Value.ImageLink);

            this.troubleshootImage.ImageLocation = logoimage;
        }

        private void InitiumTroubleshoot_Load(object sender, EventArgs e)
        {

        }


        private Tree<Node> BuildTree()
        {
            var loader = new XmlLoader();
            var doc = loader.OpenXmlReturnsXDoc();

            //var n = doc.Descendants("node").ToList();

            //line below is used for debugging
            //var xmlNodes = from e in doc.Descendants("book") select new Node { Description = e.Element("author").Value }; 

            var nodes = from x in doc.Descendants("node")
                        select new Node
                        {
                            Id = (int)x.Element("id"),
                            ParentId = (int)x.Element("parentId"),
                            Header = (string)x.Element("header"),
                            Description = (string)x.Element("description"),
                            ImageLink = (string)x.Element("imageLink"),
                            IsExecuteProcess = (string)x.Element("isExecuteProcess"),
                        };
            nodes.ToList();

            var root = nodes.FirstOrDefault();
            var tree = new Tree<Node>(root);
            var firstGenerationNodes = nodes.Where(an => an.ParentId == 0).ToList();

            foreach (var child in firstGenerationNodes)
            {
                tree.Root.Children.Add(new TreeNode<Node>(child));
            }

            //lines below used for debugging
            //var childnodes = tree.Root.ChildNodes;
            //var type = childnodes.First().GetType();
            //var data = (childnodes.First() as TreeNode<Node>).Value.Id;
            //var childId = type.GetProperty("Id");
            //var descendants = tree.Root.Descendants;

            var allNodes = tree.ChildNodes.ToList();
            var children = tree.ChildNodes.ToList();
            var subTree = tree.Subtree.ToList();

            this.BuildRecursive(tree, nodes.ToList());

            //debug
            //var updatedRoot = tree.Root;
            //var firstGen = tree.Root.ChildNodes;

            return tree;
        }

        private void BuildRecursive(TreeNode<Node> node, List<Node> nodes)
        {
            //base case
            var nodeId = (node as TreeNode<Node>).Value.Id;
            var match = nodes.Where(n => n.ParentId == nodeId).ToList();
            if (!match.Any())
            {
                return;
            }
            else
            {
                foreach (var m in match)
                {
                    (node as TreeNode<Node>).Children.Add(new TreeNode<Node>(m));
                }

                nodes.RemoveAll(n => match.Exists(m => m.Id == n.Id));

                var children = node.ChildNodes.ToList();
                foreach (var child in children)
                {
                    BuildRecursive(child as TreeNode<Node>, nodes);
                }
            }
        }
    }
}