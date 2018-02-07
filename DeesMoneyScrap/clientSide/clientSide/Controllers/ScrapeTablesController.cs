using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using clientSide.Models;

namespace clientSide.Controllers
{
    public class ScrapeTablesController : Controller
    {
        private myScrapeDbContextEntities db = new myScrapeDbContextEntities();

        // GET: ScrapeTables
        public ActionResult Index()
        {
            return View(db.ScrapeTables.ToList());
        }

        // GET: ScrapeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrapeTable scrapeTable = db.ScrapeTables.Find(id);
            if (scrapeTable == null)
            {
                return HttpNotFound();
            }
            return View(scrapeTable);
        }

        // GET: ScrapeTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScrapeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PullTime,Symbol,LastPrice,Type,ChangePerc,Volume,VolumeAvg")] ScrapeTable scrapeTable)
        {
            if (ModelState.IsValid)
            {
                db.ScrapeTables.Add(scrapeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scrapeTable);
        }

        // GET: ScrapeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrapeTable scrapeTable = db.ScrapeTables.Find(id);
            if (scrapeTable == null)
            {
                return HttpNotFound();
            }
            return View(scrapeTable);
        }

        // POST: ScrapeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PullTime,Symbol,LastPrice,Type,ChangePerc,Volume,VolumeAvg")] ScrapeTable scrapeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scrapeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scrapeTable);
        }

        // GET: ScrapeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrapeTable scrapeTable = db.ScrapeTables.Find(id);
            if (scrapeTable == null)
            {
                return HttpNotFound();
            }
            return View(scrapeTable);
        }

        // POST: ScrapeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScrapeTable scrapeTable = db.ScrapeTables.Find(id);
            db.ScrapeTables.Remove(scrapeTable);
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
