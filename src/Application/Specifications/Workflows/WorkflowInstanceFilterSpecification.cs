using MVWorkflows.Application.Specifications.Base;
using MVWorkflows.Application.Models.Workflows;

namespace MVWorkflows.Application.Specifications.Workflows
{
    internal class WorkflowInstanceFilterSpecification : HeroSpecification<WorkflowInstance>
    {
        public WorkflowInstanceFilterSpecification(string searchString)
        {
            Includes.Add(a => a.WorkflowInstantiatorUser);
            Includes.Add(a => a.Workflow);
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => (p.Workflow.DescriptionWorkflow.Contains(searchString) || p.Workflow.NomWorkflow.Contains(searchString) ||
                p.WorkflowInstantiatorUser.UserName.Contains(searchString) ||
                p.WorkflowInstantiatorUser.PhoneNumber.Contains(searchString) ||
                p.WorkflowInstantiatorUser.Matricule.ToString().Contains(searchString) ||
                p.WorkflowInstantiatorUser.Email.ToString().Contains(searchString));
            }
            else
            {
                Criteria = p => p.Id != 0;
            }
        }
    }
}
