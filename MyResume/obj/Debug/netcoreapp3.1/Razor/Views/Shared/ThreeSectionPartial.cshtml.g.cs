#pragma checksum "C:\Users\deusv\Desktop\MyResume\MyResume\Views\Shared\ThreeSectionPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bcb25ac22b2a1060399b982296ed32ea8bdae14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ThreeSectionPartial), @"mvc.1.0.view", @"/Views/Shared/ThreeSectionPartial.cshtml")]
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
#line 2 "C:\Users\deusv\Desktop\MyResume\MyResume\Views\_ViewImports.cshtml"
using MyResume.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bcb25ac22b2a1060399b982296ed32ea8bdae14", @"/Views/Shared/ThreeSectionPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7f7f6c6cfcd95f3f0a9b008b63ad0de551f17f7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ThreeSectionPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<section id=""three"">
    <h2>Feedback</h2>
    <p>If you want to contact me and you, for some reason, do not have my contact information - then you can use the form below and send me a letter by mail.</p>
    <div class=""row"">
        <div class=""col-8 col-12-small"">
");
#nullable restore
#line 8 "C:\Users\deusv\Desktop\MyResume\MyResume\Views\Shared\ThreeSectionPartial.cshtml"
             using (Html.BeginForm("SendMessage", "Home", FormMethod.Post))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""row gtr-uniform gtr-50"">
                    <div class=""col-6 col-12-xsmall"">
                        <input type=""text"" name=""name"" id=""name"" placeholder=""Name"" />
                    </div>
                    <div class=""col-6 col-12-xsmall"">
                        <input type=""email"" name=""sender"" id=""email"" placeholder=""Email"" />
                    </div>
                    <div class=""col-12"">
                        <textarea id=""message"" name=""subject"" placeholder=""Subject"" rows=""2""></textarea>

                        <textarea id=""message"" name=""body"" placeholder=""Message"" rows=""4""></textarea>
                    </div>
                    <ul class=""actions"">
                        <li><input type=""submit"" value=""Send Message"" /></li>
                    </ul>
                </div>
");
#nullable restore
#line 26 "C:\Users\deusv\Desktop\MyResume\MyResume\Views\Shared\ThreeSectionPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <p>Choose a job you like and you won\'t have to work a single day in your life.</p>\r\n\r\n</section>");
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
