using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DraGLand.Models;

namespace DraGLand.Controllers
{
    public class RacesController : Controller
    {
        private UserContext userContext = new UserContext();
        private RaceContext db = new RaceContext();

        // GET: Races
        public ActionResult Index()
        {
            return View(db.Races.ToList());
        }

        // GET: Races/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // GET: Races/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Races/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult Create([Bind(Include = "RaceId,FirstUserName,SecondUserName,BetType,Bet,PossibleWin,Status")] Race race, string type)
        {
            if (ModelState.IsValid)
            {
                string Name = User.Identity.Name;
                race.FirstUserName = Name;
                race.PossibleWin = (int)Math.Floor(race.Bet * 1.96);
                if (type == "real")
                {
                    race.BetType = "real";
                    if(userContext.Users.Find(Name).RealMoney >= race.Bet)
                    {
                        userContext.Users.Find(Name).RealMoney -= race.Bet;
                        race.Status = "waiting";
                        db.Races.Add(race);
                        db.SaveChanges();
                    }
                }
                else{
                    race.BetType = "virtual";
                    if (userContext.Users.Find(Name).GameMoney >= race.Bet)
                    {
                        userContext.Users.Find(Name).GameMoney -= race.Bet;
                        race.Status = "waiting";
                        db.Races.Add(race);
                        db.SaveChanges();
                    }
                }
            }
            return Redirect("/GameMenu/Play");
        }

        // GET: Races/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // POST: Races/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaceId,FirstUserName,SecondUserName,BetType,Bet,PossibleWin,Status")] Race race)
        {
            if (ModelState.IsValid)
            {
                db.Entry(race).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(race);
        }

        // GET: Races/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Race race = db.Races.Find(id);
            db.Races.Remove(race);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public RedirectResult Start(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                //return HttpNotFound();
            }
            string Name = User.Identity.Name;
            if (race.FirstUserName != Name)
            {
                //return HttpNotFound();
            }
            if (race.Status == "waiting")
            {
                if(race.BetType == "real")
                {
                    if(userContext.Users.Find(Name).RealMoney >= race.Bet)
                    {
                        userContext.Users.Find(Name).RealMoney -= race.Bet;
                        race.SecondUserName = Name;
                        race.Status = "started";
                        db.SaveChanges();
                    } 
                }
                else
                {
                    if (userContext.Users.Find(Name).GameMoney >= race.Bet)
                    {
                        userContext.Users.Find(Name).GameMoney -= race.Bet;
                        race.SecondUserName = Name;
                        race.Status = "started";
                        db.SaveChanges();
                    }
                }
            }
            return Redirect("/Game/Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
