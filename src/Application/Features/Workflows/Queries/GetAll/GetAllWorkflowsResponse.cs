using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVWorkflows.Application.Features.Workflows.Queries.GetAll
{
    public class GetAllWorkflowsResponse
    {
        public int Id { get; set; }
        public string NomWorkflow { get; set; }
        public string DescriptionWorkflow { get; set; }
        public string WorkflowOwnerUserID { get; set; }
        public string WorkflowOwnerUser { get; set; }
        public string TitleWorkflow { get; set; }
        public string WorkflowImageUrl { get; set; }
        public string WorkflowOwnerUserImageUrl { get; set; }
        //public DateTime DateDebut { get; set; }
        //public DateTime DateFin { get; set; }
        //public string Statut { get; set; }
    }
}
