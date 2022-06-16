//using MVWorkflows.Application.Features.Users.Queries.GetAll;
using MVWorkflows.Application.Features.Workflows.Commands.AddEdit;
using MVWorkflows.Application.Requests;
using MVWorkflows.Client.Extensions;
using MVWorkflows.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blazored.FluentValidation;
using MVWorkflows.Client.Infrastructure.Managers.Workflows.Workflows;
using MVWorkflows.Client.Infrastructure.Managers.Identity.Users;
using MVWorkflows.Application.Responses.Identity;

namespace MVWorkflows.Client.Pages.Workflows
{
    public partial class AddEditWorkflowsModal
    {
        [Inject] private IWorkflowsManager WorkflowsManager { get; set; }
        [Inject] private IUserManager UserManager { get; set; }

        [Parameter] public AddEditWorkflowsCommand AddEditWorkflowsModel { get; set; } = new();
        [CascadingParameter] private HubConnection HubConnection { get; set; }
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        private FluentValidationValidator _fluentValidationValidator;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
        private List<UserResponse> _users = new();

        public void Cancel()
        {
            MudDialog.Cancel();
        }

        private async Task SaveAsync()
        {
            var response = await WorkflowsManager.SaveAsync(AddEditWorkflowsModel);
            if (response.Succeeded)
            {
                _snackBar.Add(response.Messages[0], Severity.Success);
                await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
            HubConnection = HubConnection.TryInitialize(_navigationManager);
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }
        }

        private async Task LoadDataAsync()
        {
            await LoadImageAsync();
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            var data = await UserManager.GetAllAsync();
            if (data.Succeeded)
            {
                _users = data.Data;
            }
        }

        private async Task LoadImageAsync()
        {
            var data = await WorkflowsManager.GetWorkflowImageAsync(AddEditWorkflowsModel.Id);
            if (data.Succeeded)
            {
                var imageData = data.Data;
                if (!string.IsNullOrEmpty(imageData))
                {
                    AddEditWorkflowsModel.WorkflowImageUrl = imageData;
                }
            }
        }

        private void DeleteAsync()
        {
            AddEditWorkflowsModel.WorkflowImageUrl = null;
            AddEditWorkflowsModel.UploadRequest = new UploadRequest();
        }

        private IBrowserFile _file;

        private async Task UploadFiles(InputFileChangeEventArgs e)
        {
            _file = e.File;
            if (_file != null)
            {
                var extension = Path.GetExtension(_file.Name);
                var format = "image/png";
                var imageFile = await e.File.RequestImageFileAsync(format, 400, 400);
                var buffer = new byte[imageFile.Size];
                await imageFile.OpenReadStream().ReadAsync(buffer);
                AddEditWorkflowsModel.WorkflowImageUrl = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                AddEditWorkflowsModel.UploadRequest = new UploadRequest { Data = buffer, UploadType = Application.Enums.UploadType.Workflow, Extension = extension };
            }
        }

        private async Task<IEnumerable<String>> SearchUsers(string value)
        {
            // In real life use an asynchronous function for fetching data from an api.
            await Task.Delay(5);

            // if text is null or empty, show complete list
            if (string.IsNullOrEmpty(value))
                return _users.Select(x => x.Id);

            return _users.Where(x => x.UserName.Contains(value, StringComparison.InvariantCultureIgnoreCase) ||
                                     x.FirstName.Contains(value, StringComparison.InvariantCultureIgnoreCase) ||
                                     x.LastName.Contains(value, StringComparison.InvariantCultureIgnoreCase) ||
                                     x.PhoneNumber.Contains(value, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => x.Id);
        }
    }
}