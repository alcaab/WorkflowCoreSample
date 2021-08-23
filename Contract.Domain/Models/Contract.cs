using System;
using Contract.Domain.Enums;

namespace Contract.Domain.Models
{
    public class Contract 
    {
        public string Id { get; set; } 

        public ContractState ContractState { get;  set; }

        public ApprovalState ApprovalState { get; set; }

        public string RejectReason { get; set; }

        public DateTime ResubmissionDate { get; set; }

        public string ResubmissionReason { get; set; }

        public byte[] ContractPdf { get; set; }

    }
}
