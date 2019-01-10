using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraGLand.Controllers
{
    public class GameMenuController : Controller
    {
        // GET: GameMenu
        public ActionResult Partial()
        {
            ViewBag.Message = "Это частичное представление.";
            return View();
        }
        public ActionResult Garage()
        {
            return View();
        }
        public ActionResult Store()
        {
            return View();
        }
        public ActionResult Race()
        {
            return View();
        }
        public ActionResult Donate()
        {
            return View();
        }
        public ActionResult Money()
        {
            return View();
        }
    }
}