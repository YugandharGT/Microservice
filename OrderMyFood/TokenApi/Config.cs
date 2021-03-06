﻿using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenApi
{
    public static class Config
    {
        public static Dictionary<string,string> GetUrls(IConfiguration configuration)
        {
            Dictionary<string, string> urls = new Dictionary<string, string>();
            urls.Add("Mvc", configuration.GetValue<string>("MvcClient"));
            urls.Add("RestaurantApi", configuration.GetValue<string>("MvcClient"));
            urls.Add("ReviewApi", configuration.GetValue<string>("MvcClient"));
            urls.Add("OrderApi", configuration.GetValue<string>("MvcClient"));
            return urls;
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                 new ApiResource("Restaurant", "Restaurant Api"),
                 new ApiResource("Review", "Review Api"),
                 new ApiResource("orders", "Ordering Api"),
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
               // new IdentityResources.Email()
            };
        }

        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientUrls)
        {

            return new List<Client>()
            {
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = new [] { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    ClientUri = $"{clientUrls["Mvc"]}",
                    RedirectUris = {$"{clientUrls["Mvc"]}/signin-oidc"},
                    PostLogoutRedirectUris = {$"{clientUrls["Mvc"]}/signout-callback-oidc"},
                    AllowAccessTokensViaBrowser = false,
                    AllowOfflineAccess = true,
                    RequireConsent = false,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowedScopes = new List<string>
                    {

                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                      //  IdentityServerConstants.StandardScopes.Email,
                         "orders",
                        "restaurant",
                        "Review"
                    }

                },
                new Client
                {
                    ClientId = "restaurantswaggerui",
                    ClientName = "Restaurant Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{clientUrls["RestaurantApi"]}/swagger/o2c.html" },
                    PostLogoutRedirectUris = { $"{clientUrls["RestaurantApi"]}/swagger/" },

                     AllowedScopes = new List<string>
                     {

                        "restaurant"
                     }
        }
            };
        }

    }
}
