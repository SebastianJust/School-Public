#pragma checksum "C:\Git\School\School\Public\School-Public\Avanceret Programmering\Opgave 2 - BMI Application\BmiApplication\BmiApplication\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "727456dc9f6f4c0485440211c4cbfa8fe3ecdaa9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Git\School\School\Public\School-Public\Avanceret Programmering\Opgave 2 - BMI Application\BmiApplication\BmiApplication\Views\_ViewImports.cshtml"
using BmiApplication;

#line default
#line hidden
#line 2 "C:\Git\School\School\Public\School-Public\Avanceret Programmering\Opgave 2 - BMI Application\BmiApplication\BmiApplication\Views\_ViewImports.cshtml"
using BmiApplication.Models;

#line default
#line hidden
#line 2 "C:\Git\School\School\Public\School-Public\Avanceret Programmering\Opgave 2 - BMI Application\BmiApplication\BmiApplication\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"727456dc9f6f4c0485440211c4cbfa8fe3ecdaa9", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bbe936f97394273a0614303d7eef33d3c6726ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BmiClient.Models.BmiRequestModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("bmiForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("bmiForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("Post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("lead"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(180, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Git\School\School\Public\School-Public\Avanceret Programmering\Opgave 2 - BMI Application\BmiApplication\BmiApplication\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Andersens Apotek";


#line default
#line hidden
            BeginContext(236, 482, true);
            WriteLiteral(@"

<!-- Section: intro -->
<section id=""intro"" class=""intro"">
    <div class=""intro-content"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-6"">
                    <div class=""wow fadeInDown"" data-wow-offset=""0"" data-wow-delay=""0.1s"">
                        <h2 class=""h-ultra"">Beregn din BMI her!</h2>
                    </div>
                    <div class=""wow fadeInUp"" data-wow-offset=""0"" data-wow-delay=""0.1s"">
");
            EndContext();
#line 23 "C:\Git\School\School\Public\School-Public\Avanceret Programmering\Opgave 2 - BMI Application\BmiApplication\BmiApplication\Views\Home\Index.cshtml"
                         if (!SignInManager.IsSignedIn(User))
                        {

#line default
#line hidden
            BeginContext(808, 114, true);
            WriteLiteral("                            <h4 class=\"h-light\">Log ind  for at beregne dit <span class=\"color\">BMI </span></h4>\r\n");
            EndContext();
#line 26 "C:\Git\School\School\Public\School-Public\Avanceret Programmering\Opgave 2 - BMI Application\BmiApplication\BmiApplication\Views\Home\Index.cshtml"

                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1008, 108, true);
            WriteLiteral("                            <h4 class=\"h-light\">Du kan nu beregne dit  <span class=\"color\">BMI</span></h4>\r\n");
            EndContext();
#line 31 "C:\Git\School\School\Public\School-Public\Avanceret Programmering\Opgave 2 - BMI Application\BmiApplication\BmiApplication\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(1143, 950, true);
            WriteLiteral(@"                    </div>
                    <div class=""well well-trans"">
                        <div class=""wow fadeInRight"" data-wow-delay=""0.1s"">

                            <ul class=""lead-list"">
                                <li><span class=""fa fa-check fa-2x icon-success""></span> <span class=""list""><strong>Hvad står det for? </strong><br />BMI står for Body Mass Index. </span></li>
                                <li><span class=""fa fa-check fa-2x icon-success""></span> <span class=""list""><strong>Hvorfor?</strong><br />En BMI-test afslører, om du er overvægtig, normal eller for tynd.</span></li>
                                <li><span class=""fa fa-check fa-2x icon-success""></span> <span class=""list""><strong>Formel</strong><br />Ved at dividere kg med sin højde (i meter) i anden</span></li>
                            </ul>

                        </div>
                    </div>


                </div>

");
            EndContext();
#line 48 "C:\Git\School\School\Public\School-Public\Avanceret Programmering\Opgave 2 - BMI Application\BmiApplication\BmiApplication\Views\Home\Index.cshtml"
                 if (SignInManager.IsSignedIn(User))
                {


#line default
#line hidden
            BeginContext(2168, 633, true);
            WriteLiteral(@"                    <div class=""col-lg-6"">
                        <div class=""form-wrapper"">
                            <div class=""wow fadeInRight"" data-wow-duration=""2s"" data-wow-delay=""0.2s"">

                                <div class=""panel panel-skin"">
                                    <div class=""panel-heading"">
                                        <h3 class=""panel-title""><span class=""fa fa-calculator""></span> Beregn dit BMI <small>(Det er gratis!)</small></h3>
                                    </div>
                                    <div class=""panel-body"">
                                        ");
            EndContext();
            BeginContext(2801, 1819, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "727456dc9f6f4c0485440211c4cbfa8fe3ecdaa99422", async() => {
                BeginContext(2862, 1751, true);
                WriteLiteral(@"
                                            <div class=""row"">
                                                <div class=""col-xs-6 col-sm-6 col-md-6"">
                                                    <div class=""form-group"">
                                                        <label>Vægt (I kilo)</label>
                                                        <input type=""text"" name=""Weigth"" id=""weigth"" class=""form-control input-md"" required=""Du skal udfylde din vægt"">
                                                    </div>
                                                </div>
                                                <div class=""col-xs-6 col-sm-6 col-md-6"">
                                                    <div class=""form-group"">
                                                        <label>Højde (I meter)</label>
                                                        <input type=""text"" name=""Heigth"" id=""heigth"" class=""form-control input-md"" required="""">
                   ");
                WriteLiteral(@"                                 </div>
                                                </div>
                                            </div>

                                            <button class=""btn btn-skin btn-block btn-lg"" id=""calculateBmi"">Vis resultat</button>
                                            <p></p>
                                            <h6 id=""resultCompleted"" style=""color:green""></h6>
                                            <h6 id=""resultErr"" style=""color:red""></h6>

                                            <p class=""lead-footer"">*Denne BMI gælder for voksne over 18 år – både mænd og kvinder - med en normal kropsbygning</p>

                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4620, 184, true);
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 90 "C:\Git\School\School\Public\School-Public\Avanceret Programmering\Opgave 2 - BMI Application\BmiApplication\BmiApplication\Views\Home\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(4823, 1267, true);
            WriteLiteral(@"            </div>

        </div>
    </div>
</section>

<script>
    $(document).ready(function () {
        $(""#calculateBmi"").click(function (e) {
            document.getElementById(""calculateBmi"").innerHTML = ""Beregner..."";
            e.preventDefault();
            var settings = {
                url: '/Api/bmi',
                type: 'post',
                ""content-Type"": ""application/json"",
                data: $('#bmiForm').serialize(),
            }

            $.ajax(settings).done(function (resp) {
                document.getElementById(""calculateBmi"").innerHTML = ""Vis resultat"";
                console.log(resp);
                document.getElementById(""resultCompleted"").innerHTML = resp.text + "" (Dit bmi er: "" + resp.bmi + "")"";
                document.getElementById(""resultErr"").innerHTML = """";


            }).fail(function (err) {
                document.getElementById(""calculateBmi"").innerHTML = ""Prøv igen"";

                console.log(""Failed..."");
    ");
            WriteLiteral("            console.log(err);\r\n                document.getElementById(\"resultErr\").innerHTML = err.responseText;\r\n                document.getElementById(\"resultCompleted\").innerHTML = \"\";\r\n\r\n            });\r\n        });\r\n\r\n    });\r\n</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BmiClient.Models.BmiRequestModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
