using Microsoft.AspNetCore.Identity;
using MVWorkflows.Domain.Contracts;
using System;
using MVWorkflows.Application.Models.Identity;

namespace MVWorkflows.Application.Models.Workflows
{
    public class WorkflowInstanceStakeHolder : AuditableEntity<Int64>
    {
        public string StakeHolderUserID { get; set; }
        public virtual BlazorHeroUser StakeHolderUser { get; set; }
        public Int64 WorkflowInstanceId { get; set; }
        public virtual WorkflowInstance WorkflowInstance { get; set; }
    }
}
