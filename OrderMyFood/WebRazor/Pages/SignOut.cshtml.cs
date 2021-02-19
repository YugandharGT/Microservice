using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebRazor.Pages
{
    public class SignOutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);

            ////// "Catalog" because UrlHelper doesn't support nameof() for controllers
            ////// https://github.com/aspnet/Mvc/issues/5853
            var homeUrl = "/Index"; //Url.Action(nameof(CatalogController.Index), "Catalog");
            return new SignOutResult(OpenIdConnectDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = homeUrl });
        }
    }
}
