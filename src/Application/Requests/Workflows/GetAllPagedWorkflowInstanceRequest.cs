using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVWorkflows.Application.Requests.Workflows
{
    public class GetAllPagedWorkflowInstanceRequest:PagedRequest
    {
        public string SearchString { get; set; }
    }
}
