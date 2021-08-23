using System;

namespace Contract.Domain.Models
{
    public class DocumentTaskHistory
    {
        public int Id { get; set; }

        public string DocumentId { get; set; }

        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskId { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        

    }
}
