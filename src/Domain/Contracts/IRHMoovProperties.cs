using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVWorkflows.Domain.Contracts
{
    public interface IRHMoovProperties : IEntity
    {
        DateTime DateEmbauche { get; set; }
        int JoursDeCongeRestantAvant { get; set; }
        DateTime DateDepart { get; set; }
        int Matricule { get; set; }
    }
}
