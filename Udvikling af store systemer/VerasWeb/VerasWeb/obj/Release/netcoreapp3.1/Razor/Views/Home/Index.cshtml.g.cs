#pragma checksum "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27f5c6fb02de6002af02cb29d04f584fcb343350"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 3 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
using VerasWeb.Handlers.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
using VerasWeb.Models.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27f5c6fb02de6002af02cb29d04f584fcb343350", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b35857dd199098649926cf8d40cf1622e149676b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VerasWeb.Handlers.Models.Customer>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Image placeholder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/theme/avatar-svgrepo-com.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
   ViewData["Title"] = "Customers"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
#nullable restore
#line 9 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
  
    bool isAdministrator = User.IsInRole("Administrator"); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"row\">\n    <div class=\"col\">\n\n        <div class=\"card\">\n            <!-- Card header -->\n            <div class=\"card-header border-0\">\n                <!--Only show if logged in-->\n");
#nullable restore
#line 20 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
              
                if (isAdministrator)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h3 class=\"mb-0\">Borgere <a href=\"/home/createcustomer\" class=\"btn btn-sm btn-primary\" style=\"float: right\">New</a></h3>\n");
#nullable restore
#line 24 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            <!-- Light table -->
            <div class=""table-responsive"">
                <table class=""table align-items-center table-flush"">
                    <thead class=""thead-light"">
                        <tr>
                            <th scope=""col"" class=""sort"" data-sort=""name"">Navn</th>
                            <th scope=""col"" class=""sort"" data-sort=""cprNumber"">CPR-Nummer</th>
                            <th scope=""col"" class=""sort"" data-sort=""status"">Resultat</th>
                            <th scope=""col"" class=""sort"" data-sort=""createdBy""> Oprettet af (Id)</th>
                            <th scope=""col"" class=""sort""> Oprettet den</th>
                            <th scope=""col"" class=""sort"" data-sort=""modifiedBy""> Ændret af (Id)</th>
                            <th scope=""col"" class=""sort""> Ændret den</th>
                            <th scope=""col""></th>
                        </tr>
                    </thead>
                    <tbody class=""list"">
");
#nullable restore
#line 43 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                          
                            foreach (var customer in Model.ToList())
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <tr>

                                <th scope=""row"">
                                    <div class=""media align-items-center"">
                                        <span class=""avatar rounded-circle mr-3"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "27f5c6fb02de6002af02cb29d04f584fcb3433507340", async() => {
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
            WriteLiteral("\n                                        </span>\n                                        <div class=\"media-body\">\n");
#nullable restore
#line 54 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                             if (isAdministrator)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <a");
            BeginWriteAttribute("href", " href=\"", 2528, "\"", 2564, 2);
            WriteAttributeValue("", 2535, "/customer/", 2535, 10, true);
#nullable restore
#line 56 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
WriteAttributeValue("", 2545, customer.CprNumber, 2545, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"name mb-0 text-sm\">");
#nullable restore
#line 56 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                                                                                             Write(customer.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n");
#nullable restore
#line 57 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"

                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"name mb-0 text-sm\">");
#nullable restore
#line 61 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                                                           Write(customer.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n");
#nullable restore
#line 62 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"

                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </div>\n                                    </div>\n                                </th>\n                                    <td class=\"cprNumber\">\n                                        ");
#nullable restore
#line 68 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                   Write(customer.CprNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </td>
                                    
                                    <td>
                                        <span class=""badge badge-dot mr-4"">

                                <!--Let's handle warnings-->
");
#nullable restore
#line 75 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                 if (customer.Result != null)
                                {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                             if (customer.Result == Results.Pending)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <i class=\"bg-warning\"></i>\n                                                <span class=\"status\">Afventer</span>\n");
#nullable restore
#line 81 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"

                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                             if (customer.Result == Results.NotProven)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <i class=\"bg-success\"></i>\n                                                <span class=\"status\">Ikke påvist</span>\n");
#nullable restore
#line 87 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"

                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                             if (customer.Result == Results.Proven)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <i class=\"bg-danger\"></i>\n                                                <span class=\"status\">Påvist</span>\n");
#nullable restore
#line 93 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                             
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <i class=\"bg-warning\"></i>\n                                    <span class=\"status\">Afventer</span>\n");
#nullable restore
#line 99 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </span>\n\n                                </td>\n\n                                    <td class=\"createdBy\">\n                                        ");
#nullable restore
#line 105 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                   Write(customer.CreatedById);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </td>\n\n                                    <td class=\"createdOn\">\n                                        ");
#nullable restore
#line 109 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                   Write(customer.CreatedOn?.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </td>\n                                    \n                                    <td class=\"modifiedBy\">\n                                        ");
#nullable restore
#line 113 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                   Write(customer.ModifiedById);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </td>\n\n                                    <td class=\"modifiedOn\">\n                                        ");
#nullable restore
#line 117 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                   Write(customer.ModifiedOn?.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </td>\n                                    \n");
#nullable restore
#line 120 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                      
                                        if (isAdministrator)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <td class=""text-right"">
                                                <div class=""dropdown"">
                                                    <a class=""btn btn-sm btn-icon-only text-light"" href=""#"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                        <i class=""fas fa-ellipsis-v""></i>
                                                    </a>

                                                    <div class=""dropdown-menu dropdown-menu-right dropdown-menu-arrow"">
                                                        <a class=""dropdown-item""");
            BeginWriteAttribute("href", " href=\"", 6450, "\"", 6486, 2);
            WriteAttributeValue("", 6457, "/customer/", 6457, 10, true);
#nullable restore
#line 130 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
WriteAttributeValue("", 6467, customer.CprNumber, 6467, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Ændre kunde <i class=\"fas fa-user-edit\"></i></a>\n                                                        <a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 6617, "\"", 6660, 2);
            WriteAttributeValue("", 6624, "/home/deletecustomer?id=", 6624, 24, true);
#nullable restore
#line 131 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
WriteAttributeValue("", 6648, customer.Id, 6648, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Slet kunde <i class=\"fas fa-trash\"></i></a>\n                                                    </div>\n                                                </div>\n                                            </td>\n");
#nullable restore
#line 135 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"
                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                           \n\n                                </tr>\n");
#nullable restore
#line 140 "C:\Git\School\School\Public\School-Public\Udvikling af store systemer\VerasWeb\VerasWeb\Views\Home\Index.cshtml"

                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </tbody>\n                </table>\n            </div>\n        </div>\n    </div>\n</div>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VerasWeb.Handlers.Models.Customer>> Html { get; private set; }
    }
}
#pragma warning restore 1591
