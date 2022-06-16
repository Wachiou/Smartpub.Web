using MVWorkflows.Domain.Contracts;
using System;
using MVWorkflows.Application.Models.Identity;

namespace MVWorkflows.Application.Models.Workflows
{
    public class WorkflowInstanceActionNote : AuditableEntity<Int64>
    {
        public string ActionNoteTakedByUserID { get; set; }
        public virtual BlazorHeroUser ActionNoteTakedByUser { get; set; }
        public Int64 WorkflowInstanceActionId { get; set; }
        public virtual WorkflowInstanceActions WorkflowInstanceActions { get; set; }
        public DateTime ActionDate { get; set; }
        public string Note { get; set; }
    }
}
