using MVWorkflows.Application.Specifications.Base;
using MVWorkflows.Application.Models.RH;

namespace MVWorkflows.Application.Specifications.RH
{
    public class GroupementFilterSpecification : HeroSpecification<Groupement>
    {
        public GroupementFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.NomGroupement.Contains(searchString) || p.DescriptionGroupement.Contains(searchString);
            }
            else
            {
                Criteria = p => true;
            }
        }
    }
}
