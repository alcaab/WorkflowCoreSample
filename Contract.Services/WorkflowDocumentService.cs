using System.Threading.Tasks;
using Contract.Domain.Enums;
using Contract.Domain.Interfaces;
using Contract.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Contract.Services
{
    public class WorkflowDocumentService : IWorkflowDocumentService
    {
        private readonly ContractDbContext _context;

        public WorkflowDocumentService(ContractDbContext context)
        {
            _context = context;
        }
        public async Task<WorkflowDocument> GetWorkflowDocumentByIdAsync(string id)
        {
            return await _context
                .Set<WorkflowDocument>()
                .Include(tasks => tasks.TasksHistory)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<WorkflowDocument> GetWorkflowDocumentByRefAsync(string id, DocumentTypeEnum documentType, string definitionId, int version)
        {
            return await _context
                .Set<WorkflowDocument>()
                .Include(tasks=> tasks.TasksHistory)
                .FirstOrDefaultAsync(f => f.DocumentRefId == id && f.DocumentType == documentType && f.WorkflowDefinitionId == definitionId 
                                          && f.Version == version);
        }

        public async Task AddDocumentAsync(WorkflowDocument document)
        {
            await _context.AddAsync(document);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDocumentAsync(WorkflowDocument document)
        {
            await _context.SaveChangesAsync();
        }
    }
}
