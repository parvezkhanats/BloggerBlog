using BloggerBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerBlog.Data
{
    public static class DbInitializer
    {
        public static async Task InitializerAsync(IServiceProvider serviceProvider,
            UserManager<ApplicationUser> _userManager)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "User" };
            IdentityResult result;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    result = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            string Email = "apptechsolutions88@gmail.com";
            string password = "@parvez1984";
            if (_userManager.FindByEmailAsync(Email).Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = Email;
                user.Email = Email;
                IdentityResult resultIdentity = _userManager.CreateAsync(user, password).Result;
                if (resultIdentity.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "SuperAdmin").Wait();
                }
            }
        }

    }
}
