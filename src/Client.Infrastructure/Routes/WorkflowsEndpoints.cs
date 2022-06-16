using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVWorkflows.Client.Infrastructure.Routes
{
    public static class WorkflowsEndpoints
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/v1/workflows/export";

        public static string GetAll = "api/v1/workflows";
        public static string Delete = "api/v1/workflows";
        public static string Save = "api/v1/workflows";
        public static string GetCount = "api/v1/workflows/count";
        public static string GetWorkflowImage(int workflowId)
        {
            return $"api/v1/workflows/image/{workflowId}";
        }
    }
}
