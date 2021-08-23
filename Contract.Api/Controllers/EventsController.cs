using System.Threading.Tasks;
using Contract.Domain.Enums;
using Contract.Workflow;
using Contract.Workflow.Steps;
using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Interface;

namespace workflowcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {
        private readonly IWorkflowController _workflowService;

        public EventsController(IWorkflowController workflowService)
        {
            _workflowService = workflowService;
        }

        [HttpPost("[action]/{eventKey}")]
        public async Task<IActionResult> UploadPdf(string eventKey, [FromBody] Contract.Domain.Models.Contract model)
        {
            await _workflowService.PublishEvent(ContractSteps.UploadContractPdf, eventKey, model);

            return Ok();
        }

        [HttpPost("[action]/{eventKey}")]
        public async Task<IActionResult> CheckContract(string eventKey,
            [FromBody] Contract.Domain.Models.Contract model)
        {
            await _workflowService.PublishEvent(ContractSteps.ReviewContract, eventKey, model);

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> StartWorkflow([FromBody] Contract.Domain.Models.Contract model)
        {
            var id = await _workflowService.StartWorkflow("ContractWorkflow", 1,
                new WorkflowParams<Contract.Domain.Models.Contract>
                {
                    Model = model,
                    DocumentId = model.Id,
                    DocumentType = DocumentTypeEnum.Contract
                });

            return Ok(id);
        }
    }
}