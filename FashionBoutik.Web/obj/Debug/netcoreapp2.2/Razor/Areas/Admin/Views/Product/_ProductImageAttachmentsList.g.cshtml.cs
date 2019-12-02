#pragma checksum "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "473ed59e05fb97a9b500663e383a482adb9801da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product__ProductImageAttachmentsList), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/_ProductImageAttachmentsList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Product/_ProductImageAttachmentsList.cshtml", typeof(AspNetCore.Areas_Admin_Views_Product__ProductImageAttachmentsList))]
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
#line 2 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
using FashionBoutik.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"473ed59e05fb97a9b500663e383a482adb9801da", @"/Areas/Admin/Views/Product/_ProductImageAttachmentsList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"317a0bfc19e1e24274e9e35c7e2e2f2e851d06d6", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Product__ProductImageAttachmentsList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
 if (Model.Attachments != null && Model.Attachments.Any())
{
    var attachedFiles = Model.Attachments/*?.OrderBy(a => a.CreatedDate)*/.ToList();


#line default
#line hidden
            BeginContext(203, 134, true);
            WriteLiteral("    <div id=\"myCarousel\" class=\"carousel slide\" data-ride=\"carousel\" data-interval=\"6000\">\r\n        <ol class=\"carousel-indicators\">\r\n");
            EndContext();
#line 10 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
             for (int i = 0; i < attachedFiles.Count() - 1; i++)
            {

#line default
#line hidden
            BeginContext(418, 61, true);
            WriteLiteral("                <li data-target=\"#myCarousel\" data-slide-to=\"");
            EndContext();
            BeginContext(480, 1, false);
#line 12 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
                                                        Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(481, 9, true);
            WriteLiteral("\"></li>\r\n");
            EndContext();
#line 13 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
            }

#line default
#line hidden
            BeginContext(505, 68, true);
            WriteLiteral("        </ol>\r\n        <div class=\"carousel-inner\" role=\"listbox\">\r\n");
            EndContext();
#line 16 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
             foreach (var attachedFile in attachedFiles)
            {

#line default
#line hidden
            BeginContext(646, 288, true);
            WriteLiteral(@"            <div class=""item center-block icon-plus-overlay"">
                <figure class=""icon-plus-overlay"">
                    <ul class=""nav text-center"">
                        <!-- menu to Preview\DownLoad\Delete attachment-->
                        <li class=""dropdown"">
");
            EndContext();
            BeginContext(1052, 270, true);
            WriteLiteral(@"                            <button class=""dropdown-toggle waves-light"" data-toggle=""dropdown"" aria-expanded=""false"">
                                <span data-tooltip=""true"" data-placement=""top"" data-trigger=""hover"" title=""More"">
                                    ");
            EndContext();
            BeginContext(1323, 17, false);
#line 26 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
                               Write(attachedFile.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1340, 331, true);
            WriteLiteral(@"<i class=""img-circle "" aria-hidden=""true""></i>...
                                </span>
                            </button>
                            <ul class=""dropdown-menu dropdown-menu-right"" role=""menu"">
                                <li role=""presentation"">
                                    <a target=""_blank""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1671, "\"", 1753, 4);
            WriteAttributeValue("", 1678, "/Admin/Product/ViewAttachedFile?productId=", 1678, 42, true);
#line 31 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
WriteAttributeValue("", 1720, Model.Id, 1720, 9, false);

#line default
#line hidden
            WriteAttributeValue("", 1729, "&fileId=", 1729, 8, true);
#line 31 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
WriteAttributeValue("", 1737, attachedFile.Id, 1737, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1754, 66, true);
            WriteLiteral(" role=\"menuitem\"\r\n                                       data-id=\"");
            EndContext();
            BeginContext(1821, 15, false);
#line 32 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
                                           Write(attachedFile.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1836, 325, true);
            WriteLiteral(@""" class=""preview-productAttachedImage waves-light"">
                                        <i class=""fa fa-eye "" aria-hidden=""true""></i> Preview
                                    </a>
                                </li>
                                <li role=""presentation"">
                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2161, "\"", 2247, 4);
            WriteAttributeValue("", 2168, "/Admin/Product/DownloadAttachedFile?productId=", 2168, 46, true);
#line 37 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
WriteAttributeValue("", 2214, Model.Id, 2214, 9, false);

#line default
#line hidden
            WriteAttributeValue("", 2223, "&fileId=", 2223, 8, true);
#line 37 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
WriteAttributeValue("", 2231, attachedFile.Id, 2231, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2248, 66, true);
            WriteLiteral(" role=\"menuitem\"\r\n                                       data-id=\"");
            EndContext();
            BeginContext(2315, 15, false);
#line 38 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
                                           Write(attachedFile.Id);

#line default
#line hidden
            EndContext();
            BeginContext(2330, 367, true);
            WriteLiteral(@""" class=""download-productAttachedFile waves-light"">
                                        <i class=""fa fa-download"" aria-hidden=""true""></i> Download
                                    </a>
                                </li>

                                <li role=""presentation"">
                                    <a href=""#"" role=""menuitem"" data-id=""");
            EndContext();
            BeginContext(2698, 15, false);
#line 44 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
                                                                    Write(attachedFile.Id);

#line default
#line hidden
            EndContext();
            BeginContext(2713, 14, true);
            WriteLiteral("\" data-value=\"");
            EndContext();
            BeginContext(2728, 17, false);
#line 44 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
                                                                                                  Write(attachedFile.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2745, 439, true);
            WriteLiteral(@""" class=""delete-productAttachedFile waves-light"">
                                        <i class=""fa fa-trash"" aria-hidden=""true""></i> Delete
                                    </a>
                                </li>

                            </ul>

                        </li>
                    </ul>
                    <!-- Preview images panel -->
                    <img class=""img-responsive product-image-sm""");
            EndContext();
            BeginWriteAttribute("alt", " alt=\"", 3184, "\"", 3208, 1);
#line 54 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
WriteAttributeValue("", 3190, attachedFile.Name, 3190, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("src", " \r\n                         src=\"", 3209, "\"", 3303, 2);
            WriteAttributeValue("", 3242, "data:image;base64,", 3242, 18, true);
#line 55 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
WriteAttributeValue("", 3260, Convert.ToBase64String(attachedFile.Bytes), 3260, 43, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3304, 159, true);
            WriteLiteral("/>\r\n\r\n                    <footer class=\"icon-overlay-text\">\r\n                       \r\n                        <label class=\"secondary-grey\">added by <strong> ");
            EndContext();
            BeginContext(3464, 34, false);
#line 59 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
                                                                   Write(attachedFile.CreatorUser?.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(3498, 21, true);
            WriteLiteral(" </strong> </label>\r\n");
            EndContext();
#line 60 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
                         if (@attachedFile.CreatedDate.Year > 1900)
                        {

#line default
#line hidden
            BeginContext(3615, 59, true);
            WriteLiteral("                            <label class=\"secondary-grey\"> ");
            EndContext();
            BeginContext(3675, 65, false);
#line 62 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
                                                      Write(String.Format("{0:MMM d, yyyy HH:mm}", @attachedFile.CreatedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3740, 10, true);
            WriteLiteral("</label>\r\n");
            EndContext();
#line 63 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
                        }
                        

#line default
#line hidden
            BeginContext(3936, 80, true);
            WriteLiteral("\r\n                    </footer>\r\n                </figure>\r\n            </div>\r\n");
            EndContext();
#line 71 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
            }

#line default
#line hidden
            BeginContext(4031, 514, true);
            WriteLiteral(@"        </div>
        <a class=""left carousel-control"" href=""#myCarousel"" role=""button"" data-slide=""prev"">
            <span class=""glyphicon glyphicon-chevron-left"" aria-hidden=""true""></span>
            <span class=""sr-only"">Prev</span>
        </a>
        <a class=""right carousel-control"" href=""#myCarousel"" role=""button"" data-slide=""next"">
            <span class=""glyphicon glyphicon-chevron-right"" aria-hidden=""true""></span>
            <span class=""sr-only"">Next</span>
        </a>
    </div>
");
            EndContext();
#line 82 "F:\MY\! GIT\FashionBoutik\FashionBoutik.Web\Areas\Admin\Views\Product\_ProductImageAttachmentsList.cshtml"
}

#line default
#line hidden
            BeginContext(4548, 123, true);
            WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        $(\'.carousel-inner > .item:first-of-type\').addClass(\"active\");\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductModel> Html { get; private set; }
    }
}
#pragma warning restore 1591