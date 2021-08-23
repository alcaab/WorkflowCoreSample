using System.Threading.Tasks;
using Contract.Domain.Enums;
using Contract.Domain.Models;

namespace Contract.Domain.Interfaces
{
    public interface IWorkflowDocumentService
    {
        Task<WorkflowDocument> GetWorkflowDocumentByIdAsync(string id);

        Task<WorkflowDocument> GetWorkflowDocumentByRefAsync(string refId, DocumentTypeEnum documentType,string definitionId, int version);

        Task AddDocumentAsync(WorkflowDocument document);

        Task UpdateDocumentAsync(WorkflowDocument document);




    }
}
