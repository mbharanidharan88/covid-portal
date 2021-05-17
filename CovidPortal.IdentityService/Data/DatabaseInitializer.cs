using CovidPortal.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidPortal.IdentityService.Data
{
    public static class DatabaseInitializer
    {
        public static async Task InitTestUser(IApplicationBuilder app)
        {
            try
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    //Resolve ASP .NET Core Identity with DI help
                    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                    await context.Database.EnsureCreatedAsync();

                    var roles = new string[] { AppRoles.ADMIN_USER, AppRoles.PATIENT_USER, AppRoles.DOCTOR_USER, AppRoles.VENDOR_USER };

                    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                    foreach (var role in roles)
                    {
                        var roleStore = new RoleStore<IdentityRole>(context);

                        if (!context.Roles.Any(r => r.Name == role))
                        {
                            //await roleStore.CreateAsync(new IdentityRole(role));

                            await roleManager.CreateAsync(new IdentityRole(role));
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
