#pragma checksum "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16a8bb8ded255cd9a520e9b487537994046a8881"
// <auto-generated/>
#pragma warning disable 1591
namespace MVWorkflows.Client.Pages.Identity
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 2 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using Blazored.FluentValidation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Identity.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Identity.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Identity.Roles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Identity.RoleClaims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Identity.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Preferences;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Interceptors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Catalog.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Catalog.Brand;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Dashboard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Communication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Audit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Misc.Document;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Managers.Misc.DocumentType;

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Shared.Constants.Permission;

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Shared.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Shared.Dialogs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Settings;

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Application.Requests.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Pages.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Infrastructure.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
using MVWorkflows.Client.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
           [AllowAnonymous]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/account/reset-password/")]
    public partial class Reset : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(0);
            __builder.AddAttribute(1, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 6 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                  _resetPasswordModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 6 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                      SubmitAsync

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Blazored.FluentValidation.FluentValidationValidator>(4);
                __builder2.AddComponentReferenceCapture(5, (__value) => {
#nullable restore
#line 7 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                     _fluentValidationValidator = (Blazored.FluentValidation.FluentValidationValidator)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\r\n    ");
                __builder2.OpenComponent<MudBlazor.MudGrid>(7);
                __builder2.AddAttribute(8, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudItem>(9);
                    __builder3.AddAttribute(10, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 9 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                     12

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenElement(12, "div");
                        __builder4.AddAttribute(13, "class", "d-flex justify-center");
                        __builder4.OpenComponent<MudBlazor.MudIcon>(14);
                        __builder4.AddAttribute(15, "Icon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                CustomIcons.MoovAfricaWB

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(16, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Color>(
#nullable restore
#line 11 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                 Color.Primary

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(17, "Size", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Size>(
#nullable restore
#line 11 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                      Size.Large

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(18, "ViewBox", "0 0 50 50");
                        __builder4.AddAttribute(19, "Style", "width: 100px; height: 100px;");
                        __builder4.CloseComponent();
                        __builder4.CloseElement();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(20, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudItem>(21);
                    __builder3.AddAttribute(22, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 14 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                     12

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(23, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenElement(24, "div");
                        __builder4.AddAttribute(25, "class", "d-flex justify-center");
                        __builder4.OpenComponent<MudBlazor.MudText>(26);
                        __builder4.AddAttribute(27, "Typo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 16 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                               Typo.h4

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(28, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddContent(29, 
#nullable restore
#line 16 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                         _localizer["Reset password"]

#line default
#line hidden
#nullable disable
                            );
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.CloseElement();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(30, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudItem>(31);
                    __builder3.AddAttribute(32, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 19 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                     12

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(33, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenElement(34, "div");
                        __builder4.AddAttribute(35, "class", "d-flex justify-center");
                        __builder4.OpenComponent<MudBlazor.MudText>(36);
                        __builder4.AddAttribute(37, "Typo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 21 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                               Typo.subtitle2

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(38, "Class", "mb-n4");
                        __builder4.AddAttribute(39, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddContent(40, 
#nullable restore
#line 21 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                              _localizer["Enter email for password reset"]

#line default
#line hidden
#nullable disable
                            );
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.CloseElement();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(41, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudItem>(42);
                    __builder3.AddAttribute(43, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 24 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                     12

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(44, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MudBlazor.MudTextField<string>>(45);
                        __builder4.AddAttribute(46, "Label", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 25 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                             _localizer["E-mail"]

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(47, "For", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<string>>>(
#nullable restore
#line 25 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                  () => _resetPasswordModel.Email

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(48, "Variant", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 25 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                                                             Variant.Outlined

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(49, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(
#nullable restore
#line 25 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                _resetPasswordModel.Email

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(50, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<string>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<string>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _resetPasswordModel.Email = __value, _resetPasswordModel.Email))));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(51, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudItem>(52);
                    __builder3.AddAttribute(53, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 27 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                     12

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(54, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MudBlazor.MudTextField<string>>(55);
                        __builder4.AddAttribute(56, "Label", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 28 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                             _localizer["Password"]

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(57, "For", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<string>>>(
#nullable restore
#line 28 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                       () => _resetPasswordModel.Password

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(58, "Variant", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 28 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                                                                     Variant.Outlined

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(59, "InputType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.InputType>(
#nullable restore
#line 28 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                                                                                                   _passwordInput

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(60, "Adornment", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Adornment>(
#nullable restore
#line 28 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                                                                                                                              Adornment.End

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(61, "AdornmentIcon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 28 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                                                                                                                                                             _passwordInputIcon

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(62, "OnAdornmentClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 28 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                                                                                                                                                                                                   TogglePasswordVisibility

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddAttribute(63, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(
#nullable restore
#line 28 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                  _resetPasswordModel.Password

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(64, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<string>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<string>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _resetPasswordModel.Password = __value, _resetPasswordModel.Password))));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(65, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudItem>(66);
                    __builder3.AddAttribute(67, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 30 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                     12

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(68, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MudBlazor.MudTextField<string>>(69);
                        __builder4.AddAttribute(70, "Label", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                             _localizer["Confirm Password"]

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(71, "For", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<string>>>(
#nullable restore
#line 31 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                                      () => _resetPasswordModel.ConfirmPassword

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(72, "Variant", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 31 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                                                                                           Variant.Outlined

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(73, "InputType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.InputType>(
#nullable restore
#line 31 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                                                                                                                        InputType.Password

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(74, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(
#nullable restore
#line 31 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                          _resetPasswordModel.ConfirmPassword

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(75, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<string>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<string>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _resetPasswordModel.ConfirmPassword = __value, _resetPasswordModel.ConfirmPassword))));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(76, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudItem>(77);
                    __builder3.AddAttribute(78, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 33 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                     12

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(79, "Class", "d-flex justify-center");
                    __builder3.AddAttribute(80, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MudBlazor.MudButton>(81);
                        __builder4.AddAttribute(82, "Variant", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 34 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                Variant.Filled

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(83, "Disabled", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 34 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                            !Validated

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(84, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Color>(
#nullable restore
#line 34 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                Color.Primary

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(85, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.ButtonType>(
#nullable restore
#line 34 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                           ButtonType.Submit

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(86, "Size", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Size>(
#nullable restore
#line 34 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                                    Size.Large

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(87, "FullWidth", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 34 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                                                           true

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(88, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddContent(89, 
#nullable restore
#line 34 "C:\Users\kagouti.MOOV-AFRICA\source\repos\MVWorkFlows\src\Client\Pages\Identity\Reset.razor"
                                                                                                                                                                  _localizer["Reset Password"]

#line default
#line hidden
#nullable disable
                            );
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<Reset> _localizer { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime _jsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalStorageService _localStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IUserManager _userManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ClientPreferenceManager _clientPreferenceManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpInterceptorManager _interceptor { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _httpClient { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDialogService _dialogService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISnackbar _snackBar { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthorizationService _authorizationService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BlazorHeroStateProvider _stateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccountManager _accountManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationManager _authenticationManager { get; set; }
    }
}
#pragma warning restore 1591
