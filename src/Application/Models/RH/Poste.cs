using MVWorkflows.Domain.Contracts;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MVWorkflows.Application.Models.Identity;

namespace MVWorkflows.Application.Models.RH
{
    public class Poste : AuditableEntity<int>
    {
        public string PosteActualOwnerUserId { get; set; }
        public virtual BlazorHeroUser PosteActualOwnerUser { get; set; }
        public int PosteSuperieurId { get; set; }
        public virtual Poste PosteSuperieur { get; set; }
        public string NomPoste { get; set; }
        public string IntitulePoste { get; set; }
        public string DescriptionPoste { get; set; }
        public int IdGroupement { get; set; }
        public virtual Groupement Groupement { get; set; }
    }
}
