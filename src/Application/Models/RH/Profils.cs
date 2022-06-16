using MVWorkflows.Domain.Contracts;
using System.Collections.Generic;

namespace MVWorkflows.Application.Models.RH
{
    public class Profils : AuditableEntity<int>
    {
        public string NomProfil { get; set; }
        public string DescriptionProfil { get; set; }        
    }
}
