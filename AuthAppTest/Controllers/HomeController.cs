using AuthAppTest.Models;
using System.Linq;
using System.Web.Mvc;

namespace AuthAppTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context = new ApplicationContext();
        public ActionResult Index()
        {
            var roles  = _context.Roles.ToList();
            ViewBag.AdminCount = roles.Where(r => r.Name == "admin").Count();
            ViewBag.UserCount  = roles.Where(r => r.Name == "user").Count();
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About page.";
            return View(); 
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}