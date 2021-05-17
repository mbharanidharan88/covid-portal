using CovidPortal.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CovidPortal.HospitalAPI.Data
{
    public static class DatabaseInitializer
    {
        public static async Task InitData(IApplicationBuilder app)
        {
            try
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    //Resolve ASP .NET Core Identity with DI help
                    var context = scope.ServiceProvider.GetService<HospitalDbContext>();

                    await context.Database.EnsureCreatedAsync();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
