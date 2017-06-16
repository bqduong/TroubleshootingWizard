using System.Collections.Generic;
using System.Linq;
using Wizard.Models;

namespace Wizard.Utilities
{
    public class TreeBuilder
    {
        public Tree<Node> BuildTree()
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
                    VideoLink = (string)x.Element("videoLink"),
                    IsExecuteProcess = (string)x.Element("isExecuteProcess"),
                    ActionCode = (string)x.Element("actionCode"),
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
