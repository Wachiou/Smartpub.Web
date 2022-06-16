using Microsoft.AspNetCore.Identity;
using MVWorkflows.Application.Models.Identity;
using MVWorkflows.Domain.Contracts;
using System;

namespace MVWorkflows.Application.Models.RH
{
    public class HistoriqueAffectationPersonnel: AuditableEntity<int>
    {
        public string PersonnelAffecteUserId { get; set; }
        public virtual BlazorHeroUser PersonnelAffecteUser { get; set; }
        public DateTime DateAction { get; set; }
        public DateTime DateEffetAffectation { get; set; }
        public int PosteSourceId { get; set; }
        public int PosteDestinationId { get; set; }
        public virtual Poste PosteSource { get; set; }
        public virtual Poste PosteDestination { get; set; }
        public String NoteAffectation { get; set; }
    }
}
