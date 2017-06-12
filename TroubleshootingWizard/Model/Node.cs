using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TroubleshootingWizard
{
    public class Node
    {
        //private int id;
        //private int parentId;
        //private string description;
        //private string imgurl;
        //private List<Node> children;
        //private Node parent;

        public int? Id { get; set; }

        public int ParentId { get; set; }

        public string Header { get; set; }

        public string Description { get; set; }

        public string ImageLink { get; set; }

        public List<Node> Children { get; set; }

        public Node ParentNode { get; set; }
    }
}
