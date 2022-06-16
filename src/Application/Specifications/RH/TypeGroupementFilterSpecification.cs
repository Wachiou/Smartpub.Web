using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVWorkflows.Application.Specifications.Base;
using MVWorkflows.Application.Models.RH;

namespace MVWorkflows.Application.Specifications.RH
{
    public class TypeGroupementFilterSpecification : HeroSpecification<TypeGroupement>
    {
        public TypeGroupementFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.NomTypeGroupement.Contains(searchString) || p.DescriptionTypeGroupement.Contains(searchString) || p.IntituleTypeGroupement.Contains(searchString);
            }
            else
            {
                Criteria = p => true;
            }
        }
    }
}
