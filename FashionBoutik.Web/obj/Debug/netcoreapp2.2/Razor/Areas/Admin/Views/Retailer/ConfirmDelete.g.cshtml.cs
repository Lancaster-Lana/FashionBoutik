#pragma checksum "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Retailer\ConfirmDelete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c5edc4871b8008115341c980625534bf42673a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Retailer_ConfirmDelete), @"mvc.1.0.view", @"/Areas/Admin/Views/Retailer/ConfirmDelete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Retailer/ConfirmDelete.cshtml", typeof(AspNetCore.Areas_Admin_Views_Retailer_ConfirmDelete))]
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
#line 2 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Retailer\ConfirmDelete.cshtml"
using FashionBoutik.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c5edc4871b8008115341c980625534bf42673a5", @"/Areas/Admin/Views/Retailer/ConfirmDelete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"317a0bfc19e1e24274e9e35c7e2e2f2e851d06d6", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Retailer_ConfirmDelete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RetailerModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Retailer\ConfirmDelete.cshtml"
 using (Html.BeginForm("ConfirmDelete", "Retailer", new { area = "Admin", controller = "Retailer", id = Model.Id }, FormMethod.Post, true, new { enctype = "multipart/form-data" }))
{
    

#line default
#line hidden
            BeginContext(243, 77, false);
#line 6 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Retailer\ConfirmDelete.cshtml"
Write(Html.Partial("_ModalHeader", new ModalHeader { Heading = "Delete retailer" }));

#line default
#line hidden
            EndContext();
            BeginContext(324, 79, true);
            WriteLiteral("<div class=\"modal-body form-horizontal\">\r\n    Are you want to delete retailer \"");
            EndContext();
            BeginContext(404, 10, false);
#line 9 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Retailer\ConfirmDelete.cshtml"
                                Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(414, 12, true);
            WriteLiteral("\"?\r\n</div>\r\n");
            EndContext();
            BeginContext(431, 64, false);
#line 11 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Retailer\ConfirmDelete.cshtml"
Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(497, 288, true);
            WriteLiteral(@"    <div class=""modal-footer panel-footer"">
        <button data-dismiss=""modal"" class=""btn btn-default"" type=""button""> Cancel </button>
        <button class=""btn btn-danger"" type=""submit"">
            <i class=""glyphicon glyphicon-trash""></i>  Delete
        </button>
    </div>
");
            EndContext();
#line 18 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Retailer\ConfirmDelete.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RetailerModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
