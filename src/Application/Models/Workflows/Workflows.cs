using MVWorkflows.Application.Models.Identity;
using MVWorkflows.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVWorkflows.Application.Models.Workflows
{
    public class Workflows : AuditableEntity<int>
    {
        public string NomWorkflow { get; set; }
        public string DescriptionWorkflow { get; set; }
        public string TitleWorkflow { get; set; }

        [Column(TypeName = "text")]
        public string WorkflowImageUrl { get; set; }
        public string WorkflowOwnerUserID { get; set; }
        public virtual BlazorHeroUser WorkflowOwnerUser { get; set; }
        //public DateTime DateDebut { get; set; }
        //public DateTime DateFin { get; set; }
        //public string Statut { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Id, NomWorkflow, DescriptionWorkflow);
        }
    }
}
