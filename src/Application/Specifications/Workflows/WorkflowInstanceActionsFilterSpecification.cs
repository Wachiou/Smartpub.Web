using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVWorkflows.Application.Specifications.Base;
using MVWorkflows.Application.Models.Workflows;


namespace MVWorkflows.Application.Specifications.Workflows
{
    public class WorkflowInstanceActionsFilterSpecification : HeroSpecification<MVWorkflows.Application.Models.Workflows.WorkflowInstanceActions>
    {
        public WorkflowInstanceActionsFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.WorkflowInstance.WorkflowInstantiatorUser.UserName.Contains(searchString) 
                || p.WorkflowInstance.Workflow.NomWorkflow.Contains(searchString)
                || p.WorkflowInstance.Workflow.TitleWorkflow.Contains(searchString)
                || p.WorkflowInstance.WorkflowInstantiatorUser.Matricule.ToString().Contains(searchString)
                || p.ActionExecutedByUser.Matricule.ToString().Contains(searchString)
                || p.ActionExecutedByUser.UserName.ToString().Contains(searchString)
                || p.ActionExecutedByUser.Email.Contains(searchString)
                || p.ActionExecutedByUser.PhoneNumber.Contains(searchString);
            }
            else
            {
                Criteria = p => true;
            }
        }
    }
}
