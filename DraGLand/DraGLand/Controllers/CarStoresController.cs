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
    public class CarStoresController : Controller
    {
        private CarStoreContext db = new CarStoreContext();

        // GET: CarStores
        public ActionResult Index()
        {
            return View(db.CarStores.ToList());
        }

        // GET: CarStores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarStore carStore = db.CarStores.Find(id);
            if (carStore == null)
            {
                return HttpNotFound();
            }
            return View(carStore);
        }

        // GET: CarStores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarStoreId,Price,Photo")] CarStore carStore)
        {
            if (ModelState.IsValid)
            {
                db.CarStores.Add(carStore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carStore);
        }

        // GET: CarStores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarStore carStore = db.CarStores.Find(id);
            if (carStore == null)
            {
                return HttpNotFound();
            }
            return View(carStore);
        }

        // POST: CarStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarStoreId,Price,Photo")] CarStore carStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carStore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carStore);
        }

        // GET: CarStores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarStore carStore = db.CarStores.Find(id);
            if (carStore == null)
            {
                return HttpNotFound();
            }
            return View(carStore);
        }

        // POST: CarStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarStore carStore = db.CarStores.Find(id);
            db.CarStores.Remove(carStore);
            db.SaveChanges();
            return RedirectToAction("Index");
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
