#pragma checksum "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Views\Shared\_ModalFooter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93d1705234c78e750497cb0d06d82d0aac5d4a8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ModalFooter), @"mvc.1.0.view", @"/Views/Shared/_ModalFooter.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ModalFooter.cshtml", typeof(AspNetCore.Views_Shared__ModalFooter))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93d1705234c78e750497cb0d06d82d0aac5d4a8c", @"/Views/Shared/_ModalFooter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccc01d344a074c36d7cd76710371c690e8ca43d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ModalFooter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FashionBoutik.Models.ModalFooter>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 62, true);
            WriteLiteral("\r\n<div class=\"modal-footer\">\r\n    <button data-dismiss=\"modal\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 103, "\"", 129, 1);
#line 4 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Views\Shared\_ModalFooter.cshtml"
WriteAttributeValue("", 108, Model.CancelButtonID, 108, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(130, 39, true);
            WriteLiteral(" class=\"btn btn-default\" type=\"button\">");
            EndContext();
            BeginContext(170, 22, false);
#line 4 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Views\Shared\_ModalFooter.cshtml"
                                                                                             Write(Model.CancelButtonText);

#line default
#line hidden
            EndContext();
            BeginContext(192, 11, true);
            WriteLiteral("</button>\r\n");
            EndContext();
#line 5 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Views\Shared\_ModalFooter.cshtml"
     if (!Model.OnlyCancelButton)
    {

#line default
#line hidden
            BeginContext(245, 39, true);
            WriteLiteral("        <button class=\"btn btn-success\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 284, "\"", 310, 1);
#line 7 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Views\Shared\_ModalFooter.cshtml"
WriteAttributeValue("", 289, Model.SubmitButtonID, 289, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(311, 29, true);
            WriteLiteral(" type=\"submit\">\r\n            ");
            EndContext();
            BeginContext(341, 22, false);
#line 8 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Views\Shared\_ModalFooter.cshtml"
       Write(Model.SubmitButtonText);

#line default
#line hidden
            EndContext();
            BeginContext(363, 21, true);
            WriteLiteral("\r\n        </button>\r\n");
            EndContext();
#line 10 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Views\Shared\_ModalFooter.cshtml"
    }

#line default
#line hidden
            BeginContext(391, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FashionBoutik.Models.ModalFooter> Html { get; private set; }
    }
}
#pragma warning restore 1591
