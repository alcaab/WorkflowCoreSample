using Contract.Domain.Enums;

namespace Contract.Domain.Interfaces
{
    public interface IWorkflowDocumentParams
    {
        public string DocumentId { get; set; }
        public DocumentTypeEnum DocumentType { get; set; }
    }
}