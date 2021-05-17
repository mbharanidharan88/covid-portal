using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace CovidPortal.IdentityService
{
    public static class Config
    {
        private const string SECRET_KEY = "secret";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "roles",
                    DisplayName = "Roles",
                    Description = "Allow the service access to your user roles.",
                    UserClaims = new[] { JwtClaimTypes.Role, ClaimTypes.Role },
                    ShowInDiscoveryDocument = true,
                    Required = true,
                    Emphasize = true
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("patientAPI", "Patient API"),
                new ApiScope("hospitalAPI", "Hospital API"),
                new ApiScope("vendorAPI", "Vendor API"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource()
                {
                    Name = "patientAPI",
                    DisplayName = "Pateient API",
                    ApiSecrets =
                    {
                        new Secret(SECRET_KEY.Sha256())
                    },
                    UserClaims =
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email
                    },
                    Scopes = { "patientAPI" }
                },
                new ApiResource()
                {
                    Name = "hospitalAPI",
                    DisplayName = "Hospital API",
                    ApiSecrets =
                    {
                        new Secret(SECRET_KEY.Sha256())
                    },
                    UserClaims =
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email
                    },
                    Scopes = { "hospitalAPI" }
                },
                new ApiResource()
                {
                    Name = "vendorAPI",
                    DisplayName = "Vendor API",
                    ApiSecrets =
                    {
                        new Secret(SECRET_KEY.Sha256())
                    },
                    UserClaims =
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email
                    },
                    Scopes = { "vendorAPI" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "covidPortal_client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        "patientAPI",
                        "hospitalAPI",
                        "vendorAPI"
                    }
                },
                // interactive ASP.NET Core MVC Client
                new Client
                {
                    ClientId = "covidPortal",
                    ClientName = "Covid Portal",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Implicit,
                    //AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "patientAPI",
                        "hospitalAPI",
                        "vendorAPI",
                        "roles"
                    },
                    // where to redirect to after login
                    RedirectUris = { "https://localhost:44364/auth-callback/" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:44364/" },
                    AllowedCorsOrigins = { "https://localhost:44364" },
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600
                },
                //// JavaScript Client
                //new Client
                //{
                //    ClientId = "js",
                //    ClientName = "JavaScript Client",
                //    AllowedGrantTypes = GrantTypes.Code,
                //    RequireClientSecret = false,

                //    RedirectUris =           { "https://localhost:5004/callback.html" },
                //    PostLogoutRedirectUris = { "https://localhost:5004/index.html" },
                //    AllowedCorsOrigins =     { "https://localhost:5004" },

                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "weatherAPI"
                //    }
                //}
            };
    }
}
