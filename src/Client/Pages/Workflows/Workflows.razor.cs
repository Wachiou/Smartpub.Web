using MVWorkflows.Application.Features.Workflows.Queries.GetAll;
using MVWorkflows.Client.Extensions;
using MVWorkflows.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MVWorkflows.Application.Features.Workflows.Commands.AddEdit;
using MVWorkflows.Client.Infrastructure.Managers.Workflows.Workflows;
using MVWorkflows.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.JSInterop;


namespace MVWorkflows.Client.Pages.Workflows
{
    public partial class Workflows
    {
        [Inject] private IWorkflowsManager WorkflowsManager { get; set; }

        [CascadingParameter] private HubConnection HubConnection { get; set; }

        private List<GetAllWorkflowsResponse> _workflowsList = new();
        private GetAllWorkflowsResponse _workflows = new();
        private string _searchString = "";
        private bool _dense = false;
        private bool _striped = true;
        private bool _bordered = false;

        private ClaimsPrincipal _currentUser;
        private bool _canCreateWorkflows;
        private bool _canEditWorkflows;
        private bool _canDeleteWorkflows;
        private bool _canExportWorkflows;
        private bool _canSearchWorkflows;
        private bool _loaded;

        protected override async Task OnInitializedAsync()
        {
            _currentUser = await _authenticationManager.CurrentUser();
            _canCreateWorkflows = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Workflows.Create)).Succeeded;
            _canEditWorkflows = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Workflows.Edit)).Succeeded;
            _canDeleteWorkflows = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Workflows.Delete)).Succeeded;
            _canExportWorkflows = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Workflows.Export)).Succeeded;
            _canSearchWorkflows = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Workflows.Search)).Succeeded;

            await GetWorkflowsAsync();
            _loaded = true;
            HubConnection = HubConnection.TryInitialize(_navigationManager);
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }
        }

        private async Task GetWorkflowsAsync()
        {
            var response = await WorkflowsManager.GetAllAsync();
            if (response.Succeeded)
            {
                _workflowsList = response.Data.ToList();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private async Task Delete(int id)
        {
            string deleteContent = _localizer["Supprimer le contenu"];
            var parameters = new DialogParameters
            {
                {nameof(Shared.Dialogs.DeleteConfirmation.ContentText), string.Format(deleteContent, id)}
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Shared.Dialogs.DeleteConfirmation>(_localizer["Supprimer"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await WorkflowsManager.DeleteAsync(id);
                if (response.Succeeded)
                {
                    await Reset();
                    await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                    _snackBar.Add(response.Messages[0], Severity.Success);
                }
                else
                {
                    await Reset();
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(message, Severity.Error);
                    }
                }
            }
        }

        private async Task ExportToExcel()
        {
            var response = await WorkflowsManager.ExportToExcelAsync(_searchString);
            if (response.Succeeded)
            {
                await _jsRuntime.InvokeVoidAsync("Download", new
                {
                    ByteArray = response.Data,
                    FileName = $"{nameof(Workflows).ToLower()}_{DateTime.Now:ddMMyyyyHHmmss}.xlsx",
                    MimeType = ApplicationConstants.MimeTypes.OpenXml
                });
                _snackBar.Add(string.IsNullOrWhiteSpace(_searchString)
                    ? _localizer["Workflows exporté"]
                    : _localizer["Workflows filtrés exportés"], Severity.Success);
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private async Task InvokeModal(int id = 0)
        {
            var parameters = new DialogParameters();
            if (id != 0)
            {
                _workflows = _workflowsList.FirstOrDefault(c => c.Id == id);
                if (_workflows != null)
                {
                    parameters.Add(nameof(AddEditWorkflowsModal.AddEditWorkflowsModel), new AddEditWorkflowsCommand
                    {
                        Id = _workflows.Id,                        
                        DescriptionWorkflow = _workflows.DescriptionWorkflow,
                        NomWorkflow = _workflows.NomWorkflow,
                        TitleWorkflow = _workflows.TitleWorkflow,
                        WorkflowOwnerUserID = _workflows.WorkflowOwnerUserID
                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditWorkflowsModal>(id == 0 ? _localizer["Créer"] : _localizer["Modifier"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await Reset();
            }
        }

        private async Task Reset()
        {
            _workflows = new GetAllWorkflowsResponse();
            await GetWorkflowsAsync();
        }

        private bool Search(GetAllWorkflowsResponse workflows)
        {
            if (string.IsNullOrWhiteSpace(_searchString)) return true;
            if (workflows.NomWorkflow?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            if (workflows.DescriptionWorkflow?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            if (workflows.TitleWorkflow?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            return false;
        }
    }
}
