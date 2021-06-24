using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MebleShop.Models;

namespace MebleShop.Controllers
{
    public class IDAddressesController : Controller
    {
        private MebleDatabaseEntities2 db = new MebleDatabaseEntities2();

        // GET: IDAddresses
        public ActionResult Index()
        {
            return View(db.IDAddress.ToList());
        }

        // GET: IDAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDAddress iDAddress = db.IDAddress.Find(id);
            if (iDAddress == null)
            {
                return HttpNotFound();
            }
            return View(iDAddress);
        }

        // GET: IDAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IDAddresses/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "city,street,number")] IDAddress iDAddress,int? idkitchen)
        {
            if (ModelState.IsValid)
            {
               
                db.IDAddress.Add(iDAddress);
                db.SaveChanges();        
                return RedirectToAction("../Clients/Create"+ idkitchen);
            }

            return View(iDAddress);
        }

        // GET: IDAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDAddress iDAddress = db.IDAddress.Find(id);
            if (iDAddress == null)
            {
                return HttpNotFound();
            }
            return View(iDAddress);
        }

        // POST: IDAddresses/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,city,street,number")] IDAddress iDAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iDAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iDAddress);
        }

        // GET: IDAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDAddress iDAddress = db.IDAddress.Find(id);
            if (iDAddress == null)
            {
                return HttpNotFound();
            }
            return View(iDAddress);
        }

        // POST: IDAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IDAddress iDAddress = db.IDAddress.Find(id);
            db.IDAddress.Remove(iDAddress);
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
