#pragma checksum "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Settings\Settings.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de16033084d4bcea1bb2459be042255832d301e9"
// <auto-generated/>
#pragma warning disable 1591
namespace Project_Management_System.Client.Pages.Settings
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
#nullable restore
#line 3 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/settings")]
    public partial class Settings : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "section");
            __builder.AddAttribute(1, "class", "content-header");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "container-fluid");
            __builder.AddMarkupContent(5, "\r\n\r\n        ");
            __builder.OpenElement(6, "section");
            __builder.AddAttribute(7, "class", "content");
            __builder.AddMarkupContent(8, "\r\n            ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "row");
            __builder.AddMarkupContent(11, "\r\n\r\n                ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "col-md-3");
            __builder.AddMarkupContent(14, "\r\n                    ");
            __builder.OpenComponent<Project_Management_System.Client.Pages.Settings.SideBar>(15);
            __builder.CloseComponent();
            __builder.AddMarkupContent(16, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n\r\n                ");
            __builder.AddMarkupContent(18, "<div class=\"col-md-6\">\r\n                    <div class=\"card card-outline card-primary\">\r\n\r\n                    </div>\r\n                </div>\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IEditBody _editbodyService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IChatroom _chatroomService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IChapter _chapterService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IInvitee _inviteeService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ITopics _topicsService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccount _accountService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
