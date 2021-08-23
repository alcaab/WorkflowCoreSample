using System.Collections.Generic;
using Contract.Domain.Enums;

namespace Contract.Domain.Models
{
    public class WorkflowDocument
    {
        public string Id { get; set; }

        public string WorkflowId { get; set; }

        public string DocumentRefId { get; set; } 
        public DocumentTypeEnum DocumentType { get; set; }

        public string WorkflowDefinitionId { get; set; }

        public int Version { get; set; }

        public ICollection<DocumentTaskHistory> TasksHistory { get; set; }
        public bool IsNew { get; set; } 
    }
}