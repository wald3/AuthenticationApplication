using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace AuthAppTest.Models
{
    public class AppContextInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var adminRole = new IdentityRole("admin");
            var userRole  = new IdentityRole("user");

            if (!roleManager.RoleExists(adminRole.Name))
            {
                roleManager.Create(adminRole);
            }

            if (!roleManager.RoleExists(userRole.Name))
            {
                roleManager.Create(userRole);
            }

            var admin = new ApplicationUser
            { 
                Email = "admin@example.ru",
                UserName = "admin@example.ru"
            };
            string admin_password = "Admin_passw0rd";

            var user = new ApplicationUser
            {
                Email = "user@example.ru",
                UserName = "user@example.ru"
            };
            string user_password = "User_passw0rd";

            var result = userManager.Create(admin, admin_password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, userRole.Name);
            }

            result = userManager.Create(user, user_password);

            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, userRole.Name);
            }

            try
            {
                context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                throw e;
            }

            base.Seed(context);
        }
    }
}