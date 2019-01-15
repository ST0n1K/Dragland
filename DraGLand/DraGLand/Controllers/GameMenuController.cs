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
        private RaceContext raceContext = new RaceContext();
        
        // GET: GameMenu
        public ActionResult Partial()
        {
            ViewBag.Message = "Это частичное представление.";
            return View();
        }
        public ActionResult Garage()
        {
            ViewBag.Name = User.Identity.Name;
            return View(db.Cars.ToList());
        }
        public ActionResult Store()
        {
            return View(carStoreContext.CarStores.ToList());
        }
        public ActionResult Play(int page = 1)
        {
            var races = raceContext.Races.ToList();
            int pageSize = 3;
            IEnumerable<Race> racesPerPages = races.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = races.Count };
            PageViewModel pvm = new PageViewModel { PageInfo = pageInfo, Races = racesPerPages };
            return View(pvm);
        }

        public ActionResult Donate()
        {
            return View();
        }
        public ActionResult Money()
        {
            string Name;
            Name = User.Identity.Name;
            return View(db.Users.Find(Name));
        }
        public RedirectResult Create(int id)
        {
            string Name;
            Name = User.Identity.Name;
            if(db.Users.Find(Name).GameMoney >= carStoreContext.CarStores.Find(id).Price)
            {
                db.Users.Find(Name).GameMoney -= carStoreContext.CarStores.Find(id).Price;
                Car car = new Car();
                car.CarName = carStoreContext.CarStores.Find(id).Name;
                car.Price = carStoreContext.CarStores.Find(id).Price;
                car.Stage = 1;
                car.EngineLvl = 1;
                car.TiresLvl = 1;
                car.AccelerateLvl = 1;
                car.WeightLvl = 1;
                car.UserName = Name;
                car.Photo = carStoreContext.CarStores.Find(id).Photo;
                db.Cars.Add(car);
                db.SaveChanges();
            }
            return Redirect("/GameMenu/Garage");
        }

        public RedirectResult Exchange(string amount, string action)
        {
            string Name;
            Name = User.Identity.Name;
            if (db.Users.Find(Name).RealMoney >= int.Parse(amount))
            {
                db.Users.Find(Name).RealMoney -= int.Parse(amount);
                db.Users.Find(Name).GameMoney += int.Parse(amount) * 50;
            }
            db.SaveChanges();
            return Redirect("/GameMenu/Money");
        }

    }
}