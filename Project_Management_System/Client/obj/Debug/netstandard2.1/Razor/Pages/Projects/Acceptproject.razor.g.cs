#pragma checksum "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e6c99c26cce5cae975c7e1b5a36c3b9e9b37c37"
// <auto-generated/>
#pragma warning disable 1591
namespace Project_Management_System.Client.Pages.Projects
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/acceptproject")]
    public partial class Acceptproject : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "section");
            __builder.AddAttribute(1, "class", "content-header");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "container-fluid");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "container-fluid");
            __builder.AddMarkupContent(8, "\r\n            ");
            __builder.AddMarkupContent(9, "<div class=\"row mb-2\">\r\n                <div class=\"col-8\">\r\n                    <h1><strong>ACCEPTED PROJECTS</strong></h1>\r\n                </div>\r\n            </div>\r\n            <hr>\r\n\r\n            <br>\r\n            ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "pl-lg-5");
            __builder.AddMarkupContent(12, "\r\n                ");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "row");
            __builder.AddMarkupContent(15, "\r\n                    ");
            __Blazor.Project_Management_System.Client.Pages.Projects.Acceptproject.TypeInference.CreateGenericList_0(__builder, 16, 17, 
#nullable restore
#line 17 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                           inviteeResponses

#line default
#line hidden
#nullable disable
            , 18, (__builder2) => {
                __builder2.AddMarkupContent(19, "\r\n");
#nullable restore
#line 19 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                             foreach (var item in inviteeResponses.OrderByDescending(s => s.AcceptedDate))
                            {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(20, "                                ");
                __builder2.OpenElement(21, "div");
                __builder2.AddAttribute(22, "class", "col-lg-6");
                __builder2.AddMarkupContent(23, "\r\n                                    ");
                __builder2.OpenElement(24, "div");
                __builder2.AddAttribute(25, "class", "card card-primary card-outline");
                __builder2.AddMarkupContent(26, "\r\n                                        ");
                __builder2.OpenElement(27, "div");
                __builder2.AddAttribute(28, "class", "card-body");
                __builder2.AddMarkupContent(29, "\r\n                                            ");
                __builder2.OpenElement(30, "div");
                __builder2.AddAttribute(31, "class", "row");
                __builder2.AddMarkupContent(32, "\r\n                                                ");
                __builder2.OpenElement(33, "div");
                __builder2.AddAttribute(34, "class", "col-9");
                __builder2.AddMarkupContent(35, "\r\n                                                    ");
                __builder2.OpenElement(36, "h4");
                __builder2.AddContent(37, 
#nullable restore
#line 26 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                                         item.Topics.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(38, "\r\n                                                    ");
                __builder2.OpenElement(39, "h6");
                __builder2.AddContent(40, 
#nullable restore
#line 27 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                                         item.Topics.CreatedDate

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(41, "\r\n                                                    ");
                __builder2.OpenElement(42, "h5");
                __builder2.AddAttribute(43, "class", "text-blue");
                __builder2.AddContent(44, "#");
                __builder2.AddContent(45, 
#nullable restore
#line 28 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                                                            item.OwnerUser.UserName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(46, "\r\n                                                    <hr>\r\n                                                    ");
                __builder2.OpenElement(47, "div");
                __builder2.AddAttribute(48, "class", "row");
                __builder2.AddMarkupContent(49, "\r\n                                                        ");
                __builder2.OpenElement(50, "div");
                __builder2.AddAttribute(51, "class", "col-4");
                __builder2.AddMarkupContent(52, "\r\n                                                            ");
                __builder2.OpenElement(53, "a");
                __builder2.AddAttribute(54, "href", "projects/" + (
#nullable restore
#line 32 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                                                               item.Topics.Id

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(55, "class", "btn btn-primary");
                __builder2.AddContent(56, "VIEW DETAILS");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(57, "\r\n                                                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(58, "\r\n                                                        ");
                __builder2.OpenElement(59, "div");
                __builder2.AddAttribute(60, "class", "col-4 ml-3");
                __builder2.AddMarkupContent(61, "\r\n                                                            ");
                __builder2.OpenElement(62, "button");
                __builder2.AddAttribute(63, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                                                                () => Rejected(item.Topics.Id)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(64, "class", "btn btn-danger");
                __builder2.AddMarkupContent(65, "<i class=\"nav-icon fa fa-close\"></i> Remove");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(66, "\r\n                                                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(67, "\r\n                                                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(68, "\r\n                                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(69, "\r\n\r\n                                                ");
                __builder2.OpenElement(70, "div");
                __builder2.AddAttribute(71, "class", "col-3");
                __builder2.AddMarkupContent(72, "\r\n                                                    ");
                __builder2.OpenElement(73, "ol");
                __builder2.AddAttribute(74, "class", "breadcrumb float-sm-right");
                __builder2.AddMarkupContent(75, "\r\n                                                        ");
                __builder2.OpenElement(76, "li");
                __builder2.AddAttribute(77, "class", "breadcrumb-item");
                __builder2.AddMarkupContent(78, "\r\n");
#nullable restore
#line 43 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                                             if (item.OwnerUser.Images == null)
                                                            {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(79, "                                                                <img src=\"Images/blank-person.png\" class=\"img-fluid img-circle\" alt=\"black sample\">\r\n");
#nullable restore
#line 46 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                                            }
                                                            else
                                                            {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(80, "                                                                ");
                __builder2.OpenElement(81, "img");
                __builder2.AddAttribute(82, "src", "/Images/" + (
#nullable restore
#line 49 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                                                                   item.OwnerUser.Images

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(83, "class", "img-fluid img-circle");
                __builder2.AddAttribute(84, "alt", "black sample");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(85, "\r\n");
#nullable restore
#line 50 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                                            }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(86, "                                                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(87, "\r\n                                                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(88, "\r\n                                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(89, "\r\n                                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(90, "\r\n                                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(91, "\r\n                                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(92, "\r\n                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(93, "\r\n");
#nullable restore
#line 58 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                            }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(94, "                        ");
            }
            );
            __builder.AddMarkupContent(95, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(96, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(97, "\r\n            ");
            __builder.OpenComponent<Project_Management_System.Client.Shared.Pagination>(98);
            __builder.AddAttribute(99, "CurrentPage", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 63 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                     Request.Page

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(100, "Radius", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 63 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                                           1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(101, "TotalPagesQuantity", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 63 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                                                                  totalAmountPages

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(102, "SelectedPage", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, 
#nullable restore
#line 64 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
                                      SelectedPage

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(103, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(104, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(105, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 72 "C:\Users\olowoyinka\source\repos\BLAZOR\Project_Management_System\Project_Management_System\Client\Pages\Projects\Acceptproject.razor"
       

    List<InviteeResponse> inviteeResponses;

    PaginationRequest Request = new PaginationRequest();

    InviteeAcceptRequest inviteeAccept = new InviteeAcceptRequest();

    private int totalAmountPages;


    protected override async Task OnInitializedAsync()
    {
        try
        {
            await LoadInvitee();
        }
        catch (Exception ex)
        {

        }
    }


    private async Task LoadInvitee(string name = null)
    {
        var paginatedResponse = await _inviteeService.GetAccepted(Request, name);

        inviteeResponses = paginatedResponse.Response;

        totalAmountPages = paginatedResponse.TotalAmountPages;
    }


    private async Task Rejected(Guid? topicsId)
    {
        var topicsSelected = inviteeResponses.FirstOrDefault(x => x.Topics.Id == topicsId);

        inviteeAccept = new InviteeAcceptRequest();

        inviteeAccept.username = topicsSelected.AppUser.UserName;

        inviteeAccept.acceptance = false;

        if (await js.Confirm("Confirm", $"Remove { topicsSelected.Topics.Name } By #{ topicsSelected.OwnerUser.UserName } ?", SweetAlertMessageType.question))
        {
            await _inviteeService.RemoveInvitation(topicsId, inviteeAccept);

            await js.RemoveModal("Remove ", $"{topicsSelected.Topics.Name}", SweetAlertMessageType.success);

            await LoadInvitee();
        }
    }

    private async Task SelectedPage(int page)
    {
        Request.Page = page;

        await LoadInvitee();
    }

#line default
#line hidden
#nullable disable
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
namespace __Blazor.Project_Management_System.Client.Pages.Projects.Acceptproject
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
