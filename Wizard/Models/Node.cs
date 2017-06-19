using System.Collections.Generic;

namespace Wizard.Models
{
    public class Node
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Header { get; set; }

        public string Description { get; set; }

        public string IsExecuteProcess { get; set; }

        public string ActionCode { get; set; }

        public string ImageLink { get; set; }

        public string VideoLink { get; set; }

        public string IsYesNo { get; set; }
    }
}