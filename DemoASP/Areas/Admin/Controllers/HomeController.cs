using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoASP.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [Route("home")]
        public ActionResult Index()
        {
            return View();
        }
    }
}