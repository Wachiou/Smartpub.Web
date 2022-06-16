using MVWorkflows.Domain.Contracts;
using System.Collections.Generic;

namespace MVWorkflows.Application.Models.RH
{
    public class TypeGroupement : AuditableEntity<int>
    {
        public string NomTypeGroupement { get; set; }
        public string IntituleTypeGroupement { get; set; }
        public string DescriptionTypeGroupement { get; set; }
        public override string ToString()
        {            
            return string.Format("{0}, {1}, {2}, {3}", Id, NomTypeGroupement, IntituleTypeGroupement, DescriptionTypeGroupement); 
        }
    }
}
