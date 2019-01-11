using DraGLand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraGLand.Controllers
{
    public class GameMenuController : Controller
    {
        private UserContext db = new UserContext();
        private CarStoreContext carStoreContext = new CarStoreContext();
        
        // GET: GameMenu
        public ActionResult Partial()
        {
            ViewBag.Message = "Это частичное представление.";
            return View();
        }
        public ActionResult Garage()
        {
            string Name;
            Name = User.Identity.Name;
            return View(db.Users.Find(Name));
        }
        public ActionResult Store()
        {
            return View(carStoreContext.CarStores.ToList());
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