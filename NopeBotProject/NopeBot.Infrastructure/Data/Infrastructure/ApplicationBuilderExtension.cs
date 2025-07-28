using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NopeBotProject.Data;
using NopeBotProject.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopeBotProject.Infrastructure.Data.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdmin(services);

            var datareply = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedReplies(datareply);

            return app;
        }
        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "User" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        private static async Task SeedAdmin(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            if (await userManager.FindByNameAsync("admin") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";
                user.PhoneNumber = "0888898898";

                var result = await userManager.CreateAsync(user, "admin");
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        private static void SeedReplies(ApplicationDbContext datareply)
        {
            if(datareply.AIReplies.Any())
            {
                return; // DB has been seeded
            }
            datareply.AIReplies.AddRange(new[]
            {
              new AIReply {Tone = "Sarcastic"},
              new AIReply {Tone = "Security Bot"},
              new AIReply {Tone = "Police Bot"}
             
            });
            datareply.SaveChanges();
        }
    }

}
