#pragma checksum "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Views\Shared\_Modal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f68cf0acbbec9c55e8ea780fdbc24508c333401"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Modal), @"mvc.1.0.view", @"/Views/Shared/_Modal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Modal.cshtml", typeof(AspNetCore.Views_Shared__Modal))]
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
#line 1 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Views\_ViewImports.cshtml"
using FashionBoutik.Web;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f68cf0acbbec9c55e8ea780fdbc24508c333401", @"/Views/Shared/_Modal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccc01d344a074c36d7cd76710371c690e8ca43d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Modal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FashionBoutik.Models.BootstrapModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/multi-select/css/jquery.multiselect.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(46, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1f68cf0acbbec9c55e8ea780fdbc24508c3334013812", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(124, 8, true);
            WriteLiteral("\r\n\r\n<div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 132, "\"", 146, 1);
#line 5 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Views\Shared\_Modal.cshtml"
WriteAttributeValue("", 137, Model.ID, 137, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(147, 38, true);
            WriteLiteral(" class=\"modal fade\" aria-hidden=\"true\"");
            EndContext();
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 185, "\"", 223, 1);
#line 5 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Views\Shared\_Modal.cshtml"
WriteAttributeValue("", 203, Model.AreaLabeledId, 203, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(224, 39, true);
            WriteLiteral(" role=\"dialog\" tabindex=\"-1\">\r\n    <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 263, "\"", 305, 2);
            WriteAttributeValue("", 271, "modal-dialog", 271, 12, true);
#line 6 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Views\Shared\_Modal.cshtml"
WriteAttributeValue(" ", 283, Model.ModalSizeClass, 284, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(306, 74, true);
            WriteLiteral(">\r\n        <div class=\"modal-content\">\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FashionBoutik.Models.BootstrapModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
