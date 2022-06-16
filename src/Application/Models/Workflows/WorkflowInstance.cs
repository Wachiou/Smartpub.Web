using MVWorkflows.Domain.Contracts;
using MVWorkflows.Application.Models.Identity;
using System;

namespace MVWorkflows.Application.Models.Workflows
{
    public class WorkflowInstance: AuditableEntity<Int64>
    {
        public int WorkflowsId { get; set; }
        public virtual Workflows Workflow { get; set;}
        public string WorkflowInstantiatorUserId { get; set; }
        public virtual BlazorHeroUser WorkflowInstantiatorUser { get; set; }
        public DateTime DateInitiation { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int JoursDisponibles { get; set; }
        public int JoursDemandes { get; set; }
        public String Statut  { get; set; }
    }
}
