#pragma checksum "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\Shared\GenericSecondList.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7387ac7e78a4b0ee6bc4dc542320f08e0f45b4f"
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
#line 1 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Client.Pages.UsersAuth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Client.Respository.RespositoryInterface;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using Project_Management_System.Client.AuthService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using EndPoint.Request.UserRequest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using EndPoint.Response.ViewModelResponse;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using EndPoint.Request.ViewModelRequest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\_Imports.razor"
using EndPoint.Response.UserResponse;

#line default
#line hidden
#nullable disable
    public partial class GenericSecondList<TElement> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\Shared\GenericSecondList.razor"
 if (Elements == null)
{
    if (NullTemplate == null)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "        ");
            __builder.AddMarkupContent(1, "<div class=\"linear-activity\">\r\n            <div class=\"indeterminate\"></div>\r\n        </div>\r\n");
#nullable restore
#line 11 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\Shared\GenericSecondList.razor"
    }
    else
    {
        

#line default
#line hidden
#nullable disable
            __builder.AddContent(2, 
#nullable restore
#line 14 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\Shared\GenericSecondList.razor"
         NullTemplate

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 14 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\Shared\GenericSecondList.razor"
                     
    }
}

else if (Elements.Count() == 0)
{
    if (EmptyTemplate == null)
    {
        
    }
    else
    {
        

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, 
#nullable restore
#line 26 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\Shared\GenericSecondList.razor"
         EmptyTemplate

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 26 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\Shared\GenericSecondList.razor"
                      
    }
}

else
{
    if (@WithElementsTemplate != null)
    {
        

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, 
#nullable restore
#line 34 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\Shared\GenericSecondList.razor"
         WithElementsTemplate

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 34 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\Shared\GenericSecondList.razor"
                             
    }

    else
    {
        foreach (var element in Elements)
        {
            

#line default
#line hidden
#nullable disable
            __builder.AddContent(5, 
#nullable restore
#line 41 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\Shared\GenericSecondList.razor"
             WithIndividualElementTemplate(element)

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 41 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\Shared\GenericSecondList.razor"
                                                   ;
        }
    }
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 47 "C:\Users\olowoyinka\source\repos\Project_Management_System\Project_Management_System\Client\Shared\GenericSecondList.razor"
       
    [Parameter]
    public IEnumerable<TElement> Elements { get; set; }

    [Parameter]
    public RenderFragment NullTemplate { get; set; }

    [Parameter]
    public RenderFragment EmptyTemplate { get; set; }

    [Parameter]
    public RenderFragment WithElementsTemplate { get; set; }

    [Parameter]
    public RenderFragment<TElement> WithIndividualElementTemplate { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
