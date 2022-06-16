using MVWorkflows.Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVWorkflows.Application.Entities.Workflows
{
    public class TypeWorkflow<TUser> : AuditableEntity<int>
    {
        public string NomType { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Workflows<TUser>> Workflows { get; set; }
    }
}
