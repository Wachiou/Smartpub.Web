using MVWorkflows.Domain.Contracts;

namespace MVWorkflows.Application.Models.RH
{
    public class Groupement : AuditableEntity<int>
    {
        public string NomGroupement { get; set; }
        public string DescriptionGroupement { get; set; }
        public string IntituleGroupement { get; set; }
        public int IdTypeGroupement { get; set; }
        public virtual TypeGroupement TypeGroupement { get; set; }

        public override string ToString()
        {            
            return string.Format("{0}, {1}, {2}, {3}", Id, NomGroupement, DescriptionGroupement, IntituleGroupement);
        }
    }
}
