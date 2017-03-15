using System.Web.Mvc;

namespace Structure.Web.Controllers
{
    public class HomeController : Controller
    {
       

        // GET: Home
        public ActionResult Index()
        {
           
            return View("index");
        }

       
    }
}