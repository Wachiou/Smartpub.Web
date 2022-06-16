
using MVWorkflows.Domain.Contracts;
using System.Collections.Generic;


namespace MVWorkflows.Application.Models.RH
{
    public class ProfilPoste : AuditableEntity<int>
    {
        public int ProfilId { get; set; }
        public int PosteId { get; set; }
        public virtual Poste Poste { get; set; }
        public virtual Profils Profil { get; set; }
    }
}
