#pragma checksum "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1648f6f1736209f4041a422ac2a6f761e2913be7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category_Add), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/Add.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Category/Add.cshtml", typeof(AspNetCore.Areas_Admin_Views_Category_Add))]
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
#line 1 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\_ViewImports.cshtml"
using WorldEvents;

#line default
#line hidden
#line 2 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
using FashionBoutik.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1648f6f1736209f4041a422ac2a6f761e2913be7", @"/Areas/Admin/Views/Category/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"317a0bfc19e1e24274e9e35c7e2e2f2e851d06d6", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Category_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CategoryModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-md-3 col-sm-3 control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
 using (Html.BeginForm("Add", "Category", new { area = "Admin", controller = "Category" }, FormMethod.Post, true, new { enctype = "multipart/form-data" }))
{
    

#line default
#line hidden
            BeginContext(218, 85, false);
#line 6 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
Write(await Html.PartialAsync("_ModalHeader", new ModalHeader { Heading = "Add Category" }));

#line default
#line hidden
            EndContext();
            BeginContext(312, 64, false);
#line 8 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
#line 10 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
     if (@ViewBag.ErrorMessage != null)
    {

#line default
#line hidden
            BeginContext(428, 84, true);
            WriteLiteral("        <div class=\"alert alert-danger\">\r\n            <i class=\"fa fa-warning\"></i> ");
            EndContext();
            BeginContext(513, 20, false);
#line 13 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
                                     Write(ViewBag.ErrorMessage);

#line default
#line hidden
            EndContext();
            BeginContext(533, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 15 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
    }

#line default
#line hidden
            BeginContext(560, 147, true);
            WriteLiteral("    <div class=\"modal-body form-horizontal\">\r\n        <div class=\"row\">\r\n            <div class=\"form-group col-md-12 col-sm-12\">\r\n                ");
            EndContext();
            BeginContext(707, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1648f6f1736209f4041a422ac2a6f761e2913be76118", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 20 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CategoryName);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(785, 71, true);
            WriteLiteral("\r\n                <div class=\"col-md-9 col-sm-9\">\r\n                    ");
            EndContext();
            BeginContext(856, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1648f6f1736209f4041a422ac2a6f761e2913be77818", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 22 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CategoryName);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(909, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(932, 82, false);
#line 23 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
               Write(Html.ValidationMessageFor(m => m.CategoryName, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1014, 120, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group col-md-12 col-sm-12\">\r\n                ");
            EndContext();
            BeginContext(1134, 77, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1648f6f1736209f4041a422ac2a6f761e2913be79994", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 27 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Description);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1211, 71, true);
            WriteLiteral("\r\n                <div class=\"col-md-9 col-sm-9\">\r\n                    ");
            EndContext();
            BeginContext(1282, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1648f6f1736209f4041a422ac2a6f761e2913be711695", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 29 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Description);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1334, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1357, 83, false);
#line 30 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
               Write(Html.ValidationMessageFor(m => m.Description, null, new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1440, 121, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group  col-md-12 col-sm-12\">\r\n                ");
            EndContext();
            BeginContext(1561, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1648f6f1736209f4041a422ac2a6f761e2913be713875", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 34 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Image);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1632, 71, true);
            WriteLiteral("\r\n                <div class=\"col-md-9 col-sm-9\">\r\n                    ");
            EndContext();
            BeginContext(1703, 46, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1648f6f1736209f4041a422ac2a6f761e2913be715571", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 36 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Image);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1749, 74, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
            BeginContext(1830, 88, false);
#line 42 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
Write(await Html.PartialAsync("_ModalFooter", new ModalFooter { SubmitButtonText = "Create" }));

#line default
#line hidden
            EndContext();
#line 42 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Category\Add.cshtml"
                                                                                             
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CategoryModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
