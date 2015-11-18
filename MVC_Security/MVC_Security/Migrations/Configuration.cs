namespace MVC_Security.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVC_Security.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Security.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC_Security.Models.ApplicationDbContext";
        }

        protected override void Seed(MVC_Security.Models.ApplicationDbContext context)
        {
            //var hasher = new PasswordHasher();
            //context.Users.AddOrUpdate(u => u.UserName, new ApplicationUser
            //{
            //    UserName = "steven@vdab.be",
            //    PasswordHash = hasher.HashPassword("appelmoes")
            //});
            //if(!context.Users.Any(u =>u.UserName == "Directeur@mvc.net"))
            //{
            //    var userStore = new UserStore<ApplicationUser>(context);
            //    var userManager = new UserManager<ApplicationUser>(userStore);
                var roleStore = new RoleStore<IdentityRole>(context); 
               var roleManager = new RoleManager<IdentityRole>(roleStore);

            //    var user = new ApplicationUser { UserName = "Directeur@mvc.net" }; 
            //    userManager.Create(user, "appelmoes");
               var role = new IdentityRole { Name = "Student" };
               roleManager.Create(role);
            //    userManager.AddToRole(user.Id, "Management");

            //}
        }
    }
}
