using Akfny.Data;
using AkfnyData.Entities;
using CrossCutting.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AkfnyData
{
   public class DBInitialize
    {

        public static async Task Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore, null, null, null, null);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore, null, null, null, null, null, null, null, null);
            var AdminRole = await Roles.AddRole(roleManager, Roles.Admnin);
            var PMRole = await Roles.AddRole(roleManager, Roles.PM);
            var OrganizerRole = await Roles.AddRole(roleManager, Roles.Organizer);
            var TrainerRole = await Roles.AddRole(roleManager, Roles.Trainer);
            var TraineeRole = await Roles.AddRole(roleManager, Roles.Trainee);
            await context.SaveChangesAsync();
        }
      

    }
}
