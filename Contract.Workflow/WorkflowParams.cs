using Contract.Domain.Enums;
using Contract.Domain.Interfaces;

namespace Contract.Workflow
{
    public class WorkflowParams<T> : IWorkflowDocumentParams
    {
        public string DocumentId { get; set; }
        public DocumentTypeEnum DocumentType { get; set; }

        public T Model { get; set; }
    }
}