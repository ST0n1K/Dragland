using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraGLand.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Users = "maxsit, glazkov.hanter11@gmail.com")]
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            return View();
        }
    }
}