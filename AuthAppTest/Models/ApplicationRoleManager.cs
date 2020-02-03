using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthAppTest.Models
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        { }

        public static ApplicationRoleManager Create()
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(new ApplicationContext()));
        }
    }
}