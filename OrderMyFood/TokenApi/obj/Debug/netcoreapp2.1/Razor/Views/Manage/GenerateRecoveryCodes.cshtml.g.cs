#pragma checksum "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\Manage\GenerateRecoveryCodes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c37aff5474a56d049bb3bd4202f7173516bce153"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manage_GenerateRecoveryCodes), @"mvc.1.0.view", @"/Views/Manage/GenerateRecoveryCodes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Manage/GenerateRecoveryCodes.cshtml", typeof(AspNetCore.Views_Manage_GenerateRecoveryCodes))]
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
#line 1 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\_ViewImports.cshtml"
using TokenServiceApi;

#line default
#line hidden
#line 3 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\_ViewImports.cshtml"
using OrderMyFood.TokenApi.Models;

#line default
#line hidden
#line 4 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\_ViewImports.cshtml"
using OrderMyFood.TokenApi.Models.AccountViewModels;

#line default
#line hidden
#line 5 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\_ViewImports.cshtml"
using OrderMyFood.TokenApi.Models.ManageViewModels;

#line default
#line hidden
#line 6 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\_ViewImports.cshtml"
using IdentityServer4.Quickstart.UI;

#line default
#line hidden
#line 1 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\Manage\_ViewImports.cshtml"
using TokenServiceApi.Views.Manage;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c37aff5474a56d049bb3bd4202f7173516bce153", @"/Views/Manage/GenerateRecoveryCodes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9ec148b4812704a7506eef45420f5b18f56fefa", @"/Views/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"949ca5a155c8f81be8663903a0336dde04146eb0", @"/Views/Manage/_ViewImports.cshtml")]
    public class Views_Manage_GenerateRecoveryCodes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GenerateRecoveryCodesViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\Manage\GenerateRecoveryCodes.cshtml"
  
    ViewData["Title"] = "Recovery codes";
    ViewData.AddActivePage(ManageNavPages.TwoFactorAuthentication);

#line default
#line hidden
            BeginContext(158, 6, true);
            WriteLiteral("\r\n<h4>");
            EndContext();
            BeginContext(165, 17, false);
#line 7 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\Manage\GenerateRecoveryCodes.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(182, 377, true);
            WriteLiteral(@"</h4>
<div class=""alert alert-warning"" role=""alert"">
    <p>
        <span class=""glyphicon glyphicon-warning-sign""></span>
        <strong>Put these codes in a safe place.</strong>
    </p>
    <p>
        If you lose your device and don't have the recovery codes you will lose access to your account.
    </p>
</div>
<div class=""row"">
    <div class=""col-md-12"">
");
            EndContext();
#line 19 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\Manage\GenerateRecoveryCodes.cshtml"
         for (var row = 0; row < Model.RecoveryCodes.Count(); row += 2)
        {

#line default
#line hidden
            BeginContext(643, 18, true);
            WriteLiteral("            <code>");
            EndContext();
            BeginContext(662, 24, false);
#line 21 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\Manage\GenerateRecoveryCodes.cshtml"
             Write(Model.RecoveryCodes[row]);

#line default
#line hidden
            EndContext();
            BeginContext(686, 7, true);
            WriteLiteral("</code>");
            EndContext();
            BeginContext(699, 6, true);
            WriteLiteral("&nbsp;");
            EndContext();
            BeginContext(712, 6, true);
            WriteLiteral("<code>");
            EndContext();
            BeginContext(719, 28, false);
#line 21 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\Manage\GenerateRecoveryCodes.cshtml"
                                                                      Write(Model.RecoveryCodes[row + 1]);

#line default
#line hidden
            EndContext();
            BeginContext(747, 15, true);
            WriteLiteral("</code><br />\r\n");
            EndContext();
#line 22 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\TokenApi\Views\Manage\GenerateRecoveryCodes.cshtml"
        }

#line default
#line hidden
            BeginContext(773, 18, true);
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GenerateRecoveryCodesViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
