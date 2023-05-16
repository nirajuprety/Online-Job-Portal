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
    public class JobRequirementTablesController : Controller
    {
        private OnlineJobDbEntities db = new OnlineJobDbEntities();

        // GET: JobRequirementTables
        public ActionResult Index()
        {
            var jobRequirementTables = db.JobRequirementTables.Include(j => j.JobRequirementDetailTable).Include(j => j.PostJobTable);
            return View(jobRequirementTables.ToList());
        }

        // GET: JobRequirementTables/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    JobRequirementTable jobRequirementTable = db.JobRequirementTables.Find(id);
        //    if (jobRequirementTable == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(jobRequirementTable);
        //}

        // GET: JobRequirementTables/Create
        public ActionResult Create()
        {
            ViewBag.JobRequirementID = new SelectList(db.JobRequirementDetailTables, "JobRequirementDetailID", "JobRequirementDetails");
            ViewBag.PostJobID = new SelectList(db.PostJobTables, "PostJobID", "JobTitle");
            return View();
        }

        // POST: JobRequirementTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( JobRequirementTable jobRequirementTable)
        {
            if (ModelState.IsValid)
            {
                db.JobRequirementTables.Add(jobRequirementTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobRequirementID = new SelectList(db.JobRequirementDetailTables, "JobRequirementDetailID", "JobRequirementDetails", jobRequirementTable.JobRequirementID);
            ViewBag.PostJobID = new SelectList(db.PostJobTables, "PostJobID", "JobTitle", jobRequirementTable.PostJobID);
            return View(jobRequirementTable);
        }

        // GET: JobRequirementTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRequirementTable jobRequirementTable = db.JobRequirementTables.Find(id);
            if (jobRequirementTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobRequirementID = new SelectList(db.JobRequirementDetailTables, "JobRequirementDetailID", "JobRequirementDetails", jobRequirementTable.JobRequirementID);
            ViewBag.PostJobID = new SelectList(db.PostJobTables, "PostJobID", "JobTitle", jobRequirementTable.PostJobID);
            return View(jobRequirementTable);
        }

        // POST: JobRequirementTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( JobRequirementTable jobRequirementTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobRequirementTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobRequirementID = new SelectList(db.JobRequirementDetailTables, "JobRequirementDetailID", "JobRequirementDetails", jobRequirementTable.JobRequirementID);
            ViewBag.PostJobID = new SelectList(db.PostJobTables, "PostJobID", "JobTitle", jobRequirementTable.PostJobID);
            return View(jobRequirementTable);
        }

        // GET: JobRequirementTables/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    JobRequirementTable jobRequirementTable = db.JobRequirementTables.Find(id);
        //    if (jobRequirementTable == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(jobRequirementTable);
        //}

        //// POST: JobRequirementTables/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    JobRequirementTable jobRequirementTable = db.JobRequirementTables.Find(id);
        //    db.JobRequirementTables.Remove(jobRequirementTable);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
