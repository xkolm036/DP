#pragma checksum "C:\Develop\CarPoll\CarPool\CarPool\Views\Cars\ShowMyCars.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b7e099e185e419c32318bd156e395a187d58a07"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cars_ShowMyCars), @"mvc.1.0.view", @"/Views/Cars/ShowMyCars.cshtml")]
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
#line 2 "C:\Develop\CarPoll\CarPool\CarPool\Views\_ViewImports.cshtml"
using CarPool.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b7e099e185e419c32318bd156e395a187d58a07", @"/Views/Cars/ShowMyCars.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d02a2f03942bb399549315506c40bd821261114", @"/Views/_ViewImports.cshtml")]
    public class Views_Cars_ShowMyCars : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_PartialGenerateCards", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<button class=\"btn btn btn-primary\" id=\"add\"> Přidat nové vozidlo </button>\r\n<h1 class=\"mt-2\">Moje automobily</h1>\r\n<div id=\"content\" class=\"d-flex p-3 flex-wrap\">\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3b7e099e185e419c32318bd156e395a187d58a074050", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b7e099e185e419c32318bd156e395a187d58a075204", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>
    //click on text
    //cancel button
    $(document).on(""click"", '#dragArea', function (event) {
        console.log(""Drag area click"");

        var fileInput = $(this).closest(""#card"").find(""#fileInput"");
        fileInput.click();
    });

    //po vyberu souboru vlozim do p text
    $(document).on(""change"", '#fileInput', function (event) {
        console.log(""input change"");

        var file = new DataTransfer();
        file.items.add($(this).prop(""files"")[0]);
        $(this).closest(""#card"").find(""#fileText"").text(file.files[0].name);
    });



    //edit button
    $(document).on(""click"", '[title=""EditButton""]', function (event) {
        console.log(""edit click"");


        var topElement = $(this).closest(""#card"");

        topElement.find(""*"").removeAttr(""readonly"");
        topElement.find(""input"").removeClass(""no-border"");

        topElement.find('[title=""EditButton""]').addClass(""d-none"");
        topElement.find('[title=""DeleteButton""]').addClass");
            WriteLiteral(@"(""d-none"");

        topElement.find('[title=""CancelButton""]').removeClass(""d-none"");
        topElement.find('[title=""SaveButton""]').removeClass(""d-none"");

        topElement.find(""#dragArea"").addClass(""dragArea"");
        topElement.find(""#dragArea"").removeClass(""d-none"");
        topElement.find(""#dragArea"").find(""p"").removeClass(""d-none"");
        topElement.find("".dragImage"").addClass(""dragImageEdit"");


        topElement.find("".dragImage"").detach().appendTo(topElement.find(""#dragArea""));
    });



    //cancel button
    $(document).on(""click"", '[title=""CancelButton""]', function () {
        console.log(""Cancel click"");

        var topElement = $(this).closest(""#card"");
        topElement.find(""input"").attr(""readonly"", """");
        topElement.find(""textarea"").attr(""readonly"", """");
        topElement.find(""input"").addClass(""no-border"");

        topElement.find('[title=""EditButton""]').removeClass(""d-none"");
        topElement.find('[title=""DeleteButton""]').removeClass(""d-non");
            WriteLiteral(@"e"");

        topElement.find('[title=""CancelButton""]').addClass(""d-none"");
        topElement.find('[title=""SaveButton""]').addClass(""d-none"");

        topElement.find(""#dragArea"").addClass(""d-none"");
        topElement.find("".dragImage"").removeClass(""dragImageEdit"");

        topElement.find("".dragImage"").detach().prependTo(topElement);

    });

    //save car
    $(document).on(""click"", '[title=""SaveButton""]', function () {
        console.log(""Save click"");
        var topElement = $(this).closest(""#card"");
        var form = $(this).closest(""#card-body"").find(""form"");
        console.log(form);

        var formData = new FormData();
        console.log(form.find(""input[name=brand]"").val());
        formData.append(""id"", form.find(""input[name=id]"").val());
        formData.append(""brand"", form.find(""input[name=brand]"").val());
        formData.append(""model"", form.find(""input[name=model]"").val());
        formData.append(""seats"", form.find(""input[name=seats]"").val());
        fo");
            WriteLiteral(@"rmData.append(""color"", form.find(""input[name=color]"").val());
        formData.append(""spz"", form.find(""input[name=spz]"").val());
        formData.append(""file"", form.find(""#fileInput"").prop(""files"")[0]);
        

     

        var request = new XMLHttpRequest();
        request.open(""POST"", ""/Car/Add"");
        request.send(formData);
 

        request.onload = function () {
            if (request.status == 200) {
                form.find(""intput[title=id]"").attr(""value"", request.responseText);
                form.find(""input"").addClass(""no-border"");
                form.find(""input"").attr(""readonly"", """");
                form.find(""textarea"").attr(""readonly"", """");
                form.find(""button"").addClass(""d-none"");
                form.find('[title=""EditButton""]').removeClass(""d-none"");
                form.find('[title=""DeleteButton""]').removeClass(""d-none"");
                topElement.find(""#dragArea"").addClass(""d-none"");
                topElement.find("".dragImage"").remove");
            WriteLiteral(@"Class(""dragImageEdit"");
                topElement.find("".dragImage"").detach().prependTo(topElement);
            }
        };




    });

    //delete car
    $(document).on(""click"", '[title=""DeleteButton""]', function (event) {
        console.log(""Delete click"");

        var cardbody = $(this).closest(""#card"");
        $.ajax({
            url: ""/Car/Delete"",
            type: ""POST"",
            data: ""id="" + cardbody.find(""form"").find('input[name=""id""]').attr(""value""),
            success: function (response) {
                //cardbody.addClass(""d-none"");
                cardbody.remove();
            }
        });

    });

    //add new car
    $(document).ready(function () {
        $('button[id=""add""]').click(function () {
            console.log(""New car click"");

            $.ajax({
                url: ""/Car/AddEmpty"",
                type: ""POST"",
                success: function (response) {
                    var tmp = $(response);
                    ");
            WriteLiteral(@"tmp.find(""*"").removeAttr(""readonly"");
                    tmp.find(""input"").removeClass(""no-border"");
                    tmp.find(""#dragArea"").addClass(""dragArea"");
                    tmp.find(""#dragArea"").removeClass(""d-none"");
                    tmp.find("".dragImage"").addClass(""dragImageEdit"");
                    tmp.find("".dragImage"").detach().appendTo(tmp.find(""#dragArea""));



                    $('#content').prepend(tmp);

                }
            });
        });
    });



    $(document).ready(function () {

        //  if (dragArea != null) {

        $(document).on(""dragover dragenter"", ""#dragArea"", function (e) {
            e.preventDefault();
            this.className = ""dragArea dragOver"";

        });



        $(document).on(""drop"", ""#dragArea"", function (event) {
            console.log(""Drop"");

            event.preventDefault();
            this.className = ""dragArea"";
            var id = $(this).parent().find(""form"");
            $(this).pa");
            WriteLiteral(@"rent().find(""#fileInput"").prop('files', event.originalEvent.dataTransfer.files);
            $(this).find("".fileText"").text(event.originalEvent.dataTransfer.files[0].name)
        });

        $(document).on(""dragleave"", ""#dragArea"", function () {

            this.className = ""dragArea"";

        });
        //    };

    });
</script>
");
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
