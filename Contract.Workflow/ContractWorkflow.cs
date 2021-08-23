using System;
using Contract.Domain.Enums;
using Contract.Workflow.Steps.Contract;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Contract.Workflow
{
    public class ContractWorkflow : IWorkflow<WorkflowParams<Domain.Models.Contract>>
    {
        public string Id => "ContractWorkflow";
        public int Version => 1;

        public void Build(IWorkflowBuilder<WorkflowParams<Domain.Models.Contract>> builder)
        {

            builder
                .StartWith<PreregisterContractStep>()
                .Then<UploadContractPdfStep>()
                .Input(step=> step.EventKey,data=> data.DocumentId)
                .Then<ReviewContractStep>(switchOutput =>
                {
                    switchOutput.When(data => "Yes").Do(then =>
                        then.StartWith<ApproveContractStep>()
                    );

                    switchOutput.When(data => "No").Do(then =>
                        then.StartWith<RejectContractStep>()
                    );

                })
                .Input(step => step.EventKey, data => data.DocumentId)
                .Then(context =>
                {
                    Console.WriteLine("workflow complete");
                    return ExecutionResult.Next();
                });
        }
    }
}
