#pragma checksum "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "421c36701b5e2e15bd9b636c82276812fd6623c6"
// <auto-generated/>
#pragma warning disable 1591
namespace Project_Management_System.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Client.Pages.UsersAuth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Client.Respository.RespositoryInterface;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Client.AuthService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Shared.Models.ChatModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using EndPoint.Request.UserRequest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using EndPoint.Response.ViewModelResponse;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using EndPoint.Request.ViewModelRequest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using EndPoint.Response.UserResponse;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Blazored.TextEditor;

#line default
#line hidden
#nullable disable
    public partial class Notification : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "li");
            __builder.AddAttribute(1, "class", "nav-item dropdown");
            __builder.AddAttribute(2, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 4 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
                                          () => LoadNotification()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.OpenElement(4, "a");
            __builder.AddAttribute(5, "class", "nav-link");
            __builder.AddAttribute(6, "data-toggle", "dropdown");
            __builder.AddMarkupContent(7, "\r\n        <i class=\"fa fa-bell\"></i>\r\n        ");
            __builder.OpenElement(8, "span");
            __builder.AddAttribute(9, "class", "badge badge-warning navbar-badge");
            __builder.AddContent(10, 
#nullable restore
#line 7 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
                                                        CountUnRead.Number

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n    ");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "dropdown-menu dropdown-menu-lg dropdown-menu-right");
            __builder.AddAttribute(15, "style", "left: inherit; right: 0px;");
            __builder.AddMarkupContent(16, "\r\n        ");
            __Blazor.Project_Management_System.Client.Shared.Notification.TypeInference.CreateGenericList_0(__builder, 17, 18, 
#nullable restore
#line 10 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
                               notificationResponse

#line default
#line hidden
#nullable disable
            , 19, (__builder2) => {
                __builder2.AddMarkupContent(20, "\r\n");
#nullable restore
#line 12 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
                 foreach (var item in notificationResponse)
                {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(21, "                    <div class=\"dropdown-divider\"></div>\r\n");
#nullable restore
#line 15 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
                     if (!item.ReadStatus)
                    {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(22, "                        ");
                __builder2.OpenElement(23, "a");
                __builder2.AddAttribute(24, "href", "#");
                __builder2.AddAttribute(25, "class", "dropdown-item");
                __builder2.AddAttribute(26, "style", "background:#f8f9fa");
                __builder2.AddMarkupContent(27, "\r\n                            ");
                __builder2.OpenElement(28, "div");
                __builder2.AddAttribute(29, "class", "media");
                __builder2.AddMarkupContent(30, "\r\n                                ");
                __builder2.OpenElement(31, "div");
                __builder2.AddAttribute(32, "class", "media-body");
                __builder2.AddMarkupContent(33, "\r\n                                    ");
                __builder2.OpenElement(34, "p");
                __builder2.AddAttribute(35, "class", "text-sm");
                __builder2.AddContent(36, 
#nullable restore
#line 20 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
                                                        item.NotificationMessage

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(37, "\r\n                                    ");
                __builder2.OpenElement(38, "p");
                __builder2.AddAttribute(39, "class", "text-sm text-muted text-white");
                __builder2.AddMarkupContent(40, "<i class=\"far fa-clock mr-1\"></i> ");
                __builder2.AddContent(41, 
#nullable restore
#line 21 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
                                                                                                                item.CreatedTime

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(42, "\r\n                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(43, "\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(44, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(45, "\r\n");
#nullable restore
#line 25 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(46, "                        ");
                __builder2.OpenElement(47, "a");
                __builder2.AddAttribute(48, "href", "#");
                __builder2.AddAttribute(49, "class", "dropdown-item");
                __builder2.AddMarkupContent(50, "\r\n                            ");
                __builder2.OpenElement(51, "div");
                __builder2.AddAttribute(52, "class", "media");
                __builder2.AddMarkupContent(53, "\r\n                                ");
                __builder2.OpenElement(54, "div");
                __builder2.AddAttribute(55, "class", "media-body");
                __builder2.AddMarkupContent(56, "\r\n                                    ");
                __builder2.OpenElement(57, "p");
                __builder2.AddAttribute(58, "class", "text-sm");
                __builder2.AddContent(59, 
#nullable restore
#line 31 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
                                                        item.NotificationMessage

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(60, "\r\n                                    ");
                __builder2.OpenElement(61, "p");
                __builder2.AddAttribute(62, "class", "text-sm text-muted text-white");
                __builder2.AddMarkupContent(63, "<i class=\"far fa-clock mr-1\"></i> ");
                __builder2.AddContent(64, 
#nullable restore
#line 32 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
                                                                                                                item.CreatedTime

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(65, "\r\n                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(66, "\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(67, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(68, "\r\n");
#nullable restore
#line 36 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
                     
                }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(69, "            ");
            }
            );
            __builder.AddMarkupContent(70, "\r\n        <div class=\"dropdown-divider\"></div>\r\n        ");
            __builder.AddMarkupContent(71, "<a href=\"#\" class=\"dropdown-item dropdown-footer\">See All Notifications</a>\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 46 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Shared\Notification.razor"
       

    List<NotificationResponse> notificationResponse = new List<NotificationResponse>();

    PaginationRequest Request = new PaginationRequest();

    CountAllGetResponse CountUnRead = new CountAllGetResponse();

    UsernameResponse username;

    private HubConnection _hubConnection;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            CountUnRead = await _notificationService.CountUnRead();

            username = await _accountService.GetUser();

            _hubConnection = new HubConnectionBuilder()
                              .WithUrl(NavigationManager.ToAbsoluteUri("/chatroomHub"))
                              .Build();

            await _hubConnection.StartAsync();

            await _hubConnection.SendAsync("AddToNotification", username.UserName);

            _hubConnection.On<string, string>("notification", (message, datetime) =>
            {
                const string FMT = "O";

                DateTime now2 = DateTime.ParseExact(datetime, FMT, System.Globalization.CultureInfo.InvariantCulture);

                notificationResponse.Add(new NotificationResponse
                {
                    NotificationMessage = message,
                    CreatedTime = now2
                });

                //CountUnRead.Number++;

                StateHasChanged();
            });
        }
        catch (Exception ex)
        {

        }
    }

    private async Task LoadNotification()
    {
        var paginatedResponse = await _notificationService.GetAllAsync(Request);

        notificationResponse = paginatedResponse.Response;
    }

    protected async override Task OnParametersSetAsync()
    {
        await LoadNotification();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private INotification _notificationService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccount _accountService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
namespace __Blazor.Project_Management_System.Client.Shared.Notification
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateGenericList_0<TElement>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.Generic.IEnumerable<TElement> __arg0, int __seq1, global::Microsoft.AspNetCore.Components.RenderFragment __arg1)
        {
        __builder.OpenComponent<global::Project_Management_System.Client.Shared.GenericList<TElement>>(seq);
        __builder.AddAttribute(__seq0, "Elements", __arg0);
        __builder.AddAttribute(__seq1, "WithElementsTemplate", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591