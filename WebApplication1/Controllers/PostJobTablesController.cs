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
    public class PostJobTablesController : Controller
    {
        private OnlineJobDbEntities db = new OnlineJobDbEntities();

        // GET: PostJobTables
        public ActionResult Index()
        {
            var postJobTables = db.PostJobTables.Include(p => p.CompanyTable).Include(p => p.JobCategoryTable).Include(p => p.JobNatureTable).Include(p => p.JobStatusTable).Include(p => p.UsersTable);
            return View(postJobTables.ToList());
        }

        // GET: PostJobTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostJobTable postJobTable = db.PostJobTables.Find(id);
            if (postJobTable == null)
            {
                return HttpNotFound();
            }
            return View(postJobTable);
        }

        // GET: PostJobTables/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.CompanyTables, "CompanyID", "CompanyName");
            ViewBag.JobCategoryID = new SelectList(db.JobCategoryTables, "JobCategoryID", "JobCategory");
            ViewBag.JobNatureID = new SelectList(db.JobNatureTables, "JobNatureID", "JobNature");
            ViewBag.JobStatusID = new SelectList(db.JobStatusTables, "JobStatusID", "JobStatus");
            ViewBag.UserID = new SelectList(db.UsersTables, "UserID", "UserName");
            return View();
        }

        // POST: PostJobTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostJobID,UserID,CompanyID,JobCategoryID,JobTitle,JobDescription,MinSalary,MaxSalary,Location,Vacancy,PostDate,ApplicationLastDate,LastDate,JobRequirementID,JobStatusID,JobNatureID")] PostJobTable postJobTable)
        {
            if (ModelState.IsValid)
            {
                db.PostJobTables.Add(postJobTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.CompanyTables, "CompanyID", "CompanyName", postJobTable.CompanyID);
            ViewBag.JobCategoryID = new SelectList(db.JobCategoryTables, "JobCategoryID", "JobCategory", postJobTable.JobCategoryID);
            ViewBag.JobNatureID = new SelectList(db.JobNatureTables, "JobNatureID", "JobNature", postJobTable.JobNatureID);
            ViewBag.JobStatusID = new SelectList(db.JobStatusTables, "JobStatusID", "JobStatus", postJobTable.JobStatusID);
            ViewBag.UserID = new SelectList(db.UsersTables, "UserID", "UserName", postJobTable.UserID);
            return View(postJobTable);
        }

        // GET: PostJobTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostJobTable postJobTable = db.PostJobTables.Find(id);
            if (postJobTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.CompanyTables, "CompanyID", "CompanyName", postJobTable.CompanyID);
            ViewBag.JobCategoryID = new SelectList(db.JobCategoryTables, "JobCategoryID", "JobCategory", postJobTable.JobCategoryID);
            ViewBag.JobNatureID = new SelectList(db.JobNatureTables, "JobNatureID", "JobNature", postJobTable.JobNatureID);
            ViewBag.JobStatusID = new SelectList(db.JobStatusTables, "JobStatusID", "JobStatus", postJobTable.JobStatusID);
            ViewBag.UserID = new SelectList(db.UsersTables, "UserID", "UserName", postJobTable.UserID);
            return View(postJobTable);
        }

        // POST: PostJobTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostJobID,UserID,CompanyID,JobCategoryID,JobTitle,JobDescription,MinSalary,MaxSalary,Location,Vacancy,PostDate,ApplicationLastDate,LastDate,JobRequirementID,JobStatusID,JobNatureID")] PostJobTable postJobTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postJobTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.CompanyTables, "CompanyID", "CompanyName", postJobTable.CompanyID);
            ViewBag.JobCategoryID = new SelectList(db.JobCategoryTables, "JobCategoryID", "JobCategory", postJobTable.JobCategoryID);
            ViewBag.JobNatureID = new SelectList(db.JobNatureTables, "JobNatureID", "JobNature", postJobTable.JobNatureID);
            ViewBag.JobStatusID = new SelectList(db.JobStatusTables, "JobStatusID", "JobStatus", postJobTable.JobStatusID);
            ViewBag.UserID = new SelectList(db.UsersTables, "UserID", "UserName", postJobTable.UserID);
            return View(postJobTable);
        }

        // GET: PostJobTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostJobTable postJobTable = db.PostJobTables.Find(id);
            if (postJobTable == null)
            {
                return HttpNotFound();
            }
            return View(postJobTable);
        }

        // POST: PostJobTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostJobTable postJobTable = db.PostJobTables.Find(id);
            db.PostJobTables.Remove(postJobTable);
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
