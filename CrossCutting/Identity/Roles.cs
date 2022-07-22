using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Identity
{
    public static class Roles
    {

        public const string Admnin = "Admin";
        public const string PM = "PM";
        public const string Trainer = "Trainer";
        public const string Trainee = "Trainee";
        public const string Organizer = "Organizer";
        public static async Task<IdentityRole> AddRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = roleName });
                role = await roleManager.FindByNameAsync(roleName);
            }
            return role;
        }
    }
}
