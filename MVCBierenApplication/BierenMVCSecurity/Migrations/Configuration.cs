namespace BierenMVCSecurity.Migrations
{
    using BierenMVCSecurity.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BierenMVCSecurity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BierenMVCSecurity.Models.ApplicationDbContext";
        }

        protected override void Seed(BierenMVCSecurity.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context); 
            var userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var user = context.Users.FirstOrDefault(u => u.UserName == "test@mail.net");

            userManager.AddToRole(user.Id, "Administrator");
            //var role = new IdentityRole { Name = "Administrator" }; 
            //roleManager.Create(role);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
