using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseLayer;

namespace WebApplication1.Controllers
{
    public class CompanyTablesController : Controller
    {
        private OnlineJobDbEntities db = new OnlineJobDbEntities();

        // GET: CompanyTables
        public ActionResult Index()
        {
            var companyTables = db.CompanyTables.Include(c => c.UsersTable);
            return View(companyTables.ToList());
        }

        // GET: CompanyTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyTable companyTable = db.CompanyTables.Find(id);
            if (companyTable == null)
            {
                return HttpNotFound();
            }
            return View(companyTable);
        }

        // GET: CompanyTables/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.UsersTables, "UserID", "UserName");
            return View();
        }

        // POST: CompanyTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,UserID,CompanyName,ContactNo,PhoneNo,EmailAddress,Logo,Description")] CompanyTable companyTable)
        {
            if (ModelState.IsValid)
            {
                db.CompanyTables.Add(companyTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.UsersTables, "UserID", "UserName", companyTable.UserID);
            return View(companyTable);
        }

        // GET: CompanyTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyTable companyTable = db.CompanyTables.Find(id);
            if (companyTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.UsersTables, "UserID", "UserName", companyTable.UserID);
            return View(companyTable);
        }

        // POST: CompanyTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,UserID,CompanyName,ContactNo,PhoneNo,EmailAddress,Logo,Description")] CompanyTable companyTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.UsersTables, "UserID", "UserName", companyTable.UserID);
            return View(companyTable);
        }

        // GET: CompanyTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyTable companyTable = db.CompanyTables.Find(id);
            if (companyTable == null)
            {
                return HttpNotFound();
            }
            return View(companyTable);
        }

        // POST: CompanyTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyTable companyTable = db.CompanyTables.Find(id);
            db.CompanyTables.Remove(companyTable);
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
