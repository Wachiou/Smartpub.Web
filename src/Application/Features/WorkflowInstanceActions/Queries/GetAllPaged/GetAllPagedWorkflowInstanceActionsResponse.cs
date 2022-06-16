using System;
using System.ComponentModel.DataAnnotations;

namespace MVWorkflows.Application.Features.WorkflowInstance.Queries.GetAllPaged
{
    public class GetAllPagedWorkflowInstanceActionsResponse
    {
         public Int64 Id { get; set; }
        public string ActionExecutedByUserID { get; set; }
        public string ActionExecutedByUserName { get; set; }
        public int ActionExecutedByUserMatricule { get; set; }
        public Int64 WorkflowInstanceId { get; set; }
        public string WorkflowInstanceNomWorkflow { get; set; }
        public DateTime WorkflowInstanceDateDebut { get; set; }
        public DateTime WorkflowInstanceDateFin { get; set; }
        public int WorkflowInstanceJoursDisponibles { get; set; }
        public int WorkflowInstanceJoursDemandes { get; set; }
        public string StateBefore { get; set; }
        public string StateAfter { get; set; }
        public string Commentaire { get; set; }
        public DateTime DateAction { get; set; }
        public DateTime DateEffetNouvelEtat { get; set; }
    }
}