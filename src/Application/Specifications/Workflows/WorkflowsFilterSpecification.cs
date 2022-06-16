using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVWorkflows.Application.Specifications.Base;
using MVWorkflows.Application.Models.Workflows;


namespace MVWorkflows.Application.Specifications.Workflows
{
    public class WorkflowsFilterSpecification : HeroSpecification<MVWorkflows.Application.Models.Workflows.Workflows>
    {
        public WorkflowsFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.NomWorkflow.Contains(searchString) || p.DescriptionWorkflow.Contains(searchString);
            }
            else
            {
                Criteria = p => true;
            }
        }
    }
}
