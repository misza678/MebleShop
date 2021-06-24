using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MebleShop.Models;

namespace MebleShop.Controllers
{
    public class KitchensController : Controller
    {
        private MebleDatabaseEntities2 db = new MebleDatabaseEntities2();

        // GET: Kitchens
        public ActionResult Index()
        {
            return View(db.Kitchen.ToList());
        }

        // GET: Kitchens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitchen kitchen = db.Kitchen.Find(id);
            if (kitchen == null)
            {
                return HttpNotFound();
            }
            return View(kitchen);
        }




        [Authorize]
        public ActionResult StartOrder(int id)
        {
            Order order = new Order
            {
                IDKitchen = id
            };

            db.Order.Add(order);
            db.SaveChanges();
            return RedirectToAction("../IDAddresses/Create");





        }









        // GET: Kitchens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kitchens/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDKitchen,Name,desc,Price,IDstyle")] Kitchen kitchen)
        {
            if (ModelState.IsValid)
            {
                db.Kitchen.Add(kitchen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kitchen);
        }

        // GET: Kitchens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitchen kitchen = db.Kitchen.Find(id);
            if (kitchen == null)
            {
                return HttpNotFound();
            }
            return View(kitchen);
        }

        // POST: Kitchens/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDKitchen,Name,desc,Price,IDstyle")] Kitchen kitchen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kitchen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kitchen);
        }

        // GET: Kitchens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitchen kitchen = db.Kitchen.Find(id);
            if (kitchen == null)
            {
                return HttpNotFound();
            }
            return View(kitchen);
        }

        // POST: Kitchens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kitchen kitchen = db.Kitchen.Find(id);
            db.Kitchen.Remove(kitchen);
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
