using System;
using System.ComponentModel.DataAnnotations;

namespace MVWorkflows.Application.Features.WorkflowInstance.Queries.GetAllPaged
{
    public class GetAllPagedWorkflowInstanceResponse
    {
        public Int64 Id { get; set; }
        public int WorkflowsId { get; set; }
        public String WorkflowName { get; set; }
        public string WorkflowInstantiatorUserId { get; set; }
        public String WorkflowUserName { get; set; }
        public DateTime DateInitiation { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int JoursDisponibles { get; set; }
        public int JoursDemandes { get; set; }
        public String Statut { get; set; }
    }
}