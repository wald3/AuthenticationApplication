using AuthAppTest.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AuthAppTest
{ 
    // TODO: Add logger and DI
    // TODO: Add DI control for all managers
    // TODO: User profile improvements(claims, personal data,  etc.)
    // TODO: View models validation attributes
    // TODO: Add different logic of ineractin with system based on user Role
    // TODO: Bootstrap fixes

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<ApplicationContext>(new AppContextInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
