#pragma checksum "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Cars\_PartialGenerateCards.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "736eb6779db9e1bb43d4fba43c81098aae3b0547"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cars__PartialGenerateCards), @"mvc.1.0.view", @"/Views/Cars/_PartialGenerateCards.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"736eb6779db9e1bb43d4fba43c81098aae3b0547", @"/Views/Cars/_PartialGenerateCards.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d02a2f03942bb399549315506c40bd821261114", @"/Views/_ViewImports.cshtml")]
    public class Views_Cars__PartialGenerateCards : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Cars\_PartialGenerateCards.cshtml"
 foreach (Car c in (List<Car>)ViewData["Cars"])
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card ml-md-2 mb-2\"  style=\"width:320px\"");
            BeginWriteAttribute("id", " id=\"", 107, "\"", 117, 1);
#nullable restore
#line 3 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Cars\_PartialGenerateCards.cshtml"
WriteAttributeValue("", 112, c.id, 112, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
       <img class=""card-img-top"" src=""img_avatar1.png"" alt=""Card image"" style=""width:100%"">
        <div class=""card-body"">

            <div class=""row"">
                <div class=""col-5""><label>Výrobce:</label></div>
                <div class=""col-7""><label> <input class=""form-control bg-light no-border"" type=""text"" id=""bbbb"" name=""brand""");
            BeginWriteAttribute("value", " value=\"", 470, "\"", 486, 1);
#nullable restore
#line 9 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Cars\_PartialGenerateCards.cshtml"
WriteAttributeValue("", 478, c.brand, 478, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly></label></div>
            </div>

            <div class=""row"">
                <div class=""col-5""><label>Model:</label></div>
                <div class=""col-7""><label> <input class=""form-control bg-light no-border"" type=""text"" id=""bbbb"" name=""model""");
            BeginWriteAttribute("value", " value=\"", 754, "\"", 770, 1);
#nullable restore
#line 14 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Cars\_PartialGenerateCards.cshtml"
WriteAttributeValue("", 762, c.model, 762, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly></label></div>
            </div>

            <div class=""row"">
                <div class=""col-5""><label>Počet míst:</label></div>
                <div class=""col-7""><label> <input class=""form-control bg-light no-border"" type=""text"" id=""bbbb"" name=""seats""");
            BeginWriteAttribute("value", " value=\"", 1043, "\"", 1059, 1);
#nullable restore
#line 19 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Cars\_PartialGenerateCards.cshtml"
WriteAttributeValue("", 1051, c.seats, 1051, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly></label></div>
            </div>

            <div class=""row"">
                <div class=""col-5""><label>Barva: </label></div>
                <div class=""col-7""><label> <input class=""form-control bg-light no-border"" type=""text"" id=""country"" name=""color""");
            BeginWriteAttribute("value", " value=\"", 1331, "\"", 1347, 1);
#nullable restore
#line 24 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Cars\_PartialGenerateCards.cshtml"
WriteAttributeValue("", 1339, c.color, 1339, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly></label></div>
            </div>

            <div class=""row"">
                <div class=""col-5""><label>SPZ: </label></div>
                <div class=""col-7""><label> <input class=""no-border form-control bg-light"" type=""text"" id=""country"" name=""spz""");
            BeginWriteAttribute("value", " value=\"", 1615, "\"", 1629, 1);
#nullable restore
#line 29 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Cars\_PartialGenerateCards.cshtml"
WriteAttributeValue("", 1623, c.spz, 1623, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly></label></div>
            </div>
            <label>Popis:</label><br />
            <textarea class=""form-control bg-light"" readonly></textarea>
            <br />   <br />

            <a href=""#"" class=""btn btn-primary"" title=""EditButton"">Edit</a>
            <a href=""#"" class=""btn btn-primary d-none"" title=""CancelButton"">Cancel</a>
            <a href=""#"" class=""btn btn-primary d-none"" title=""SaveButton"">Save</a>
            <a href=""#"" class=""btn btn-primary"" title=""DeleteButton"">Delete</a>

        </div>
    </div>
");
#nullable restore
#line 42 "D:\OneDrive\Desktop\CarPoll\CarPool\CarPool\Views\Cars\_PartialGenerateCards.cshtml"
}

#line default
#line hidden
#nullable disable
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
