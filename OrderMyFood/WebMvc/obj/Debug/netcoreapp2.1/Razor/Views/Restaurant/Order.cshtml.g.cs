#pragma checksum "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\WebMvc\Views\Restaurant\Order.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e44c3847fef1b7e613148336a534714e7a9a992b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restaurant_Order), @"mvc.1.0.view", @"/Views/Restaurant/Order.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Restaurant/Order.cshtml", typeof(AspNetCore.Views_Restaurant_Order))]
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
#line 1 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\WebMvc\Views\_ViewImports.cshtml"
using OrderMyFood.Web.WebMvc;

#line default
#line hidden
#line 2 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\WebMvc\Views\_ViewImports.cshtml"
using OrderMyFood.Web.WebMvc.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e44c3847fef1b7e613148336a534714e7a9a992b", @"/Views/Restaurant/Order.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc70aa04cc66dd3988b12c4b3572a58311a3d96f", @"/Views/_ViewImports.cshtml")]
    public class Views_Restaurant_Order : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(168, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\WebMvc\Views\Restaurant\Order.cshtml"
  
    ViewData["Title"] = "Restaurant";


#line default
#line hidden
            BeginContext(218, 473, true);
            WriteLiteral(@"
<div class=""container"">
    <div class=""table-responsive"">
        <table class=""table"">
            <thead>
                <tr>
                    <th>Restaurant ID</th>
                    <th>Name</th>
                    <th>Location</th>
                    <th>Distance</th>
                    <th>Cuisine</th>
                    <th>Budget</th>
                    <th>Ratings</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 25 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\WebMvc\Views\Restaurant\Order.cshtml"
                 if (Model.Restaurants.Count() > 0)
                {
                    

#line default
#line hidden
#line 27 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\WebMvc\Views\Restaurant\Order.cshtml"
                     foreach (var restaurant in @Model.Restaurants)
                    {
                       
                    }

#line default
#line hidden
#line 30 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\WebMvc\Views\Restaurant\Order.cshtml"
                     
                }
                else
                {

#line default
#line hidden
            BeginContext(963, 154, true);
            WriteLiteral("                    <div class=\"esh-catalog-items row\">\r\n                        THERE ARE NO RESULTS THAT MATCH YOUR SEARCH\r\n                    </div>\r\n");
            EndContext();
#line 37 "D:\Technology\Dotnet-Projects\VS19\Microservice\OrderMyFood\WebMvc\Views\Restaurant\Order.cshtml"
                }

#line default
#line hidden
            BeginContext(1136, 68, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    \r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591