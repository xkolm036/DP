#pragma checksum "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "758a2e20ae771eaabda97693de79e97ab173d453"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Route_FindRouteResolutTable), @"mvc.1.0.view", @"/Views/Route/FindRouteResolutTable.cshtml")]
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
#line 1 "C:\Develop\CarPoll\CarPool\CarPool\Views\_ViewImports.cshtml"
using CarPool;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
using CarPool.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"758a2e20ae771eaabda97693de79e97ab173d453", @"/Views/Route/FindRouteResolutTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d02a2f03942bb399549315506c40bd821261114", @"/Views/_ViewImports.cshtml")]
    public class Views_Route_FindRouteResolutTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 3 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
#nullable restore
#line 5 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
 if (TempData.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table table-hover"">
        <thead>
            <tr>
                <th>Datum</th>
                <th>Cas</th>
                <th>Odkud</th>
                <th>Kam</th>
                <th>Volná Místa</th>
                <th>Cena</th>
                <th>Detail</th>
                <th>Připojit se</th>


            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 24 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
             foreach (Route routeFromDb in (List<Route>)ViewData["Routes"])
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 27 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
               Write(routeFromDb.date.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
               Write(routeFromDb.date.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
               Write(routeFromDb.startDestination);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
               Write(routeFromDb.finalDestination);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
               Write(routeFromDb.seats);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 32 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
               Write(routeFromDb.price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 948, "\"", 991, 2);
            WriteAttributeValue("", 955, "/Route/ShowDetail?id=", 955, 21, true);
#nullable restore
#line 33 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
WriteAttributeValue("", 976, routeFromDb.id, 976, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Detail</a></td>\r\n\r\n");
#nullable restore
#line 35 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
                 if (routeFromDb.connected == false)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td><a href=\"#\"");
            BeginWriteAttribute("id", " id=\"", 1120, "\"", 1140, 1);
#nullable restore
#line 37 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
WriteAttributeValue("", 1125, routeFromDb.id, 1125, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" title=\"join\">Připojit se</a></td>\r\n");
#nullable restore
#line 38 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
                }
                else if (routeFromDb.connected == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td><a href=\"#\"");
            BeginWriteAttribute("id", " id=\"", 1307, "\"", 1327, 1);
#nullable restore
#line 41 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
WriteAttributeValue("", 1312, routeFromDb.id, 1312, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" title=\"leave\">Odhlásit se</a></td>\r\n");
#nullable restore
#line 42 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td><a href=\"#\"");
            BeginWriteAttribute("id", " id=\"", 1460, "\"", 1480, 1);
#nullable restore
#line 45 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
WriteAttributeValue("", 1465, routeFromDb.id, 1465, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" title=\"delete\">Smazat</a></td>\r\n");
#nullable restore
#line 46 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 48 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 52 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
}
else
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-4 mx-auto mt-auto\">\r\n        <div class=\"card card-body mb-2 ,mt-5\">\r\n            ");
#nullable restore
#line 58 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"
       Write(TempData["EmptyErrMessage"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 61 "C:\Develop\CarPoll\CarPool\CarPool\Views\Route\FindRouteResolutTable.cshtml"




}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "758a2e20ae771eaabda97693de79e97ab173d45310093", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>


    $('a[title=""join""]').click(function () {
        var link = $(this);

        $.ajax({ //send request to find city/street

            url: ""/Route/JoinRoute"",
            type: ""POST"",
            data: { id: link.attr(""id"") },  //data send to controller
            success: function () {
                link.attr(""title"", ""leave"");
                link.text(""Odhlásit se"");
            }
        });
    });


    $('a[title=""leave""]').click(function () {
        var link = $(this);

        $.ajax({ //send request to find city/street

            url: ""/Route/LeaveRoute"",
            type: ""POST"",
            data: { id: link.attr(""id"") },  //data send to controller
            success: function () {
                link.attr(""title"", ""join"");
                link.text(""Přihásit se"");
            }
        });
    });


  $('a[title=""delete""]').click(function () {
        var link = $(this);

        $.ajax({ //send request to find city/street

       ");
            WriteLiteral(@"     url: ""/Route/Delete"",
            type: ""POST"",
            data: { id: link.attr(""id"") },  //data send to controller
            success: function () {
                link.parent().parent().hide();
               
            }
        });
    });





</script>");
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
