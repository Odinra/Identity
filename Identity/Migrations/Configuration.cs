namespace Identity.Migrations
{
    using Identity.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Identity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Identity.Models.ApplicationDbContext context)
        {
            //var hasher = new PasswordHasher();
            //context.Users.AddOrUpdate(u => u.UserName,
            //            new ApplicationUser { UserName = "Odinra",
            //                PasswordHash = hasher.HashPassword("password")}
            //    );
            if(!context.Users.Any(u => u.UserName == "Odinra"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Odinra"};

                manager.Create(user, "password");
            }
        }
    }
}
