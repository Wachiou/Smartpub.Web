using MVWorkflows.Domain.Contracts;
using MVWorkflows.Application.Models.Identity;
using System;

namespace MVWorkflows.Application.Models.Workflows
{
    public class WorkflowInstanceActions : AuditableEntity<Int64>
    {
        public string ActionExecutedByUserID { get; set; }
        public virtual BlazorHeroUser ActionExecutedByUser { get; set; }
        public Int64 WorkflowInstanceId { get; set; }
        public virtual WorkflowInstance WorkflowInstance { get; set; }
        public string StateBefore { get; set; }
        public string StateAfter { get; set; }
        public string Commentaire { get; set; }
        public DateTime DateAction { get; set; }
        public DateTime DateEffetNouvelEtat { get; set; }
    }
}
