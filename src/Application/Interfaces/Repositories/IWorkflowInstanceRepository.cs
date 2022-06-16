using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVWorkflows.Application.Interfaces.Repositories
{
    public interface IWorkflowInstanceRepository
    {
        Task<bool> IsWorkflowInstanceUsed(int workflowsId);
    }
}
