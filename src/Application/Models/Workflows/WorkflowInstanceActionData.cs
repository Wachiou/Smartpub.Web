using MVWorkflows.Domain.Contracts;
using System;
using MVWorkflows.Application.Models.Identity;

namespace MVWorkflows.Application.Models.Workflows
{
    public class WorkflowInstanceActionData : AuditableEntity<Int64>
    {
        public Int64 WokflowsInstanceActionId { get; set; }
        public virtual WorkflowInstanceActions WorkflowInstanceActions { get; set; }
        public DateTime ActionDate { get; set; }
        public string DataType { get; set; }
        public string DataName { get; set; }
        public string DataValue { get; set; }
    }
}
