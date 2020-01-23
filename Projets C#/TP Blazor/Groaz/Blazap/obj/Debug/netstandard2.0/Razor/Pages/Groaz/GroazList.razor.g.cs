#pragma checksum "C:\partage\Blazor\Groaz\Blazap\Pages\Groaz\GroazList.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "277a86227a858d0795efe95917d6d268be0af737"
// <auto-generated/>
#pragma warning disable 1591
namespace Blazap.Pages.Groaz
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using Blazap;

#line default
#line hidden
#line 7 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using Blazap.Shared;

#line default
#line hidden
#line 2 "C:\partage\Blazor\Groaz\Blazap\Pages\Groaz\GroazList.razor"
using Services;

#line default
#line hidden
#line 4 "C:\partage\Blazor\Groaz\Blazap\Pages\Groaz\GroazList.razor"
using Models;

#line default
#line hidden
#line 5 "C:\partage\Blazor\Groaz\Blazap\Pages\Groaz\GroazList.razor"
using DTOs;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/groaz-list")]
    public partial class GroazList : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Liste des groaz</h3>\r\n");
#line 7 "C:\partage\Blazor\Groaz\Blazap\Pages\Groaz\GroazList.razor"
 if (GroazSet!=null)
{    
    

#line default
#line hidden
#line 9 "C:\partage\Blazor\Groaz\Blazap\Pages\Groaz\GroazList.razor"
     foreach (var g in GroazSet)
    {

#line default
#line hidden
            __builder.AddContent(1, "        ");
            __builder.OpenElement(2, "a");
            __builder.AddAttribute(3, "href", "groaz-detail/" + (
#line 11 "C:\partage\Blazor\Groaz\Blazap\Pages\Groaz\GroazList.razor"
                                g.Id

#line default
#line hidden
            ));
            __builder.AddMarkupContent(4, "\r\n                ");
            __builder.OpenComponent<Blazap.Pages.Groaz.GroazItem>(5);
            __builder.AddAttribute(6, "Groaz", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazap.Models.Groaz>(
#line 12 "C:\partage\Blazor\Groaz\Blazap\Pages\Groaz\GroazList.razor"
                                   g

#line default
#line hidden
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(7, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n");
#line 14 "C:\partage\Blazor\Groaz\Blazap\Pages\Groaz\GroazList.razor"
    }

#line default
#line hidden
#line 14 "C:\partage\Blazor\Groaz\Blazap\Pages\Groaz\GroazList.razor"
     
}

#line default
#line hidden
        }
        #pragma warning restore 1998
#line 17 "C:\partage\Blazor\Groaz\Blazap\Pages\Groaz\GroazList.razor"
       
    IEnumerable<Groaz> GroazSet;

    protected async override Task OnInitializedAsync()
    {

        this.GroazSet = await this.service.getGroazSet();
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private GroazHttpService service { get; set; }
    }
}
#pragma warning restore 1591