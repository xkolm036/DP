#pragma checksum "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Home\FindRoute.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54bd8eb29359fdab9def1322932e8ea0fdabdffa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FindRoute), @"mvc.1.0.view", @"/Views/Home/FindRoute.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\_ViewImports.cshtml"
using CarPool;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\_ViewImports.cshtml"
using CarPool.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Home\FindRoute.cshtml"
using Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54bd8eb29359fdab9def1322932e8ea0fdabdffa", @"/Views/Home/FindRoute.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d02a2f03942bb399549315506c40bd821261114", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FindRoute : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

    <h2>Nalezené jízdy</h2>
    
    <table class=""table table-hover"">
        <thead>
            <tr>
                <th>Datum</th>
                <th>Cas</th>
                <th>Odkud</th>
                <th>Kam</th>
                <th>Volná Místa</th>
                <th>Cena</th>
                <th> </th>
             
            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 21 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Home\FindRoute.cshtml"
             foreach (Route RouteFromDb in (List<Route>)ViewData["Routes"])
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 24 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Home\FindRoute.cshtml"
               Write(RouteFromDb.date.ToString("dd.MM"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Home\FindRoute.cshtml"
               Write(RouteFromDb.date.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Home\FindRoute.cshtml"
               Write(RouteFromDb.startDest);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Home\FindRoute.cshtml"
               Write(RouteFromDb.finalDestination);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Home\FindRoute.cshtml"
               Write(RouteFromDb.seats);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Home\FindRoute.cshtml"
               Write(RouteFromDb.price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>Pripojit se</td>\r\n            </tr>\r\n");
#nullable restore
#line 32 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Home\FindRoute.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
