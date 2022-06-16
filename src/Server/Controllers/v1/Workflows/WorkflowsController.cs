using MVWorkflows.Application.Features.Workflows.Queries.GetAll;
using MVWorkflows.Application.Features.Workflows.Queries.GetById;
using MVWorkflows.Application.Features.Workflows.Queries.GetWorkflowImage;
using MVWorkflows.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MVWorkflows.Application.Features.Workflows.Commands.AddEdit;
using MVWorkflows.Application.Features.Workflows.Commands.Delete;
using MVWorkflows.Application.Features.Workflows.Queries.Export;


namespace MVWorkflows.Server.Controllers.v1.Workflows
{
    public class WorkflowsController : BaseApiController<WorkflowsController>
    {
        /// <summary>
        /// Get All Brands
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Workflows.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workflows = await _mediator.Send(new GetAllWorkflowsQuery());
            return Ok(workflows);
        }

        /// <summary>
        /// Get a Product Image by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Workflows.View)]
        [HttpGet("image/{id}")]
        public async Task<IActionResult> GettWorkflowImageAsync(int id)
        {
            var result = await _mediator.Send(new GetWorkflowsImageQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Get a Brand By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 Ok</returns>
        [Authorize(Policy = Permissions.Workflows.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var workflows = await _mediator.Send(new GetWorkflowsByIdQuery() { Id = id });
            return Ok(workflows);
        }

        /// <summary>
        /// Create/Update a Brand
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Workflows.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditWorkflowsCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete a Brand
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Workflows.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteWorkflowsCommand { Id = id }));
        }

        /// <summary>
        /// Search Brands and Export to Excel
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [Authorize(Policy = Permissions.Workflows.Export)]
        [HttpGet("export")]
        public async Task<IActionResult> Export(string searchString = "")
        {
            return Ok(await _mediator.Send(new ExportWorkflowsQuery(searchString)));
        }
    }
}
