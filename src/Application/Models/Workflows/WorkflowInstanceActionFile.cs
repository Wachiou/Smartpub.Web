using MVWorkflows.Domain.Contracts;
using System;
using MVWorkflows.Application.Models.Identity;

namespace MVWorkflows.Application.Models.Workflows
{
    public class WorkflowInstanceActionFile:AuditableEntity<Int64>
    {
        public string ActionFileRecordedByUserID { get; set; }
        public virtual BlazorHeroUser ActionFileRecordedByUser { get; set; }
        public Int64 WorkflowInstanceActionsId { get; set; }
        public virtual WorkflowInstanceActions WorkflowInstanceActions { get; set; }
        public DateTime ActionDate { get; set; }
        public DateTime DateUploaded { get; set; }
        public String FileName { get; set; }
        public byte[] FileContent { get; set; }
        public String MIMEType { get; set; }
    }
}
