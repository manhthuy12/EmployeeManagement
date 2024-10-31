using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    
    public class tb_DIVISIONController : Controller
    {
        private Manage db = new Manage();
        
        // GET: tb_DIVISION
        public ActionResult Index()
        {
            return View(db.tb_DIVISION.ToList());
        }

        // GET: tb_DIVISION/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                ViewBag.ds1 = db.tb_EMPLOYEE.Where(s => s.DepartmentID == id).ToList();
                return View();
            }
            tb_DIVISION tb_DIVISION = db.tb_DIVISION.Find(id);
            if (tb_DIVISION == null)
            {
                return HttpNotFound();
            }
            return View(tb_DIVISION);
        }

        // GET: tb_DIVISION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_DIVISION/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DivisionID,DivisionName")] tb_DIVISION tb_DIVISION)
        {
            if (ModelState.IsValid)
            {
                db.tb_DIVISION.Add(tb_DIVISION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_DIVISION);
        }

        // GET: tb_DIVISION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DIVISION tb_DIVISION = db.tb_DIVISION.Find(id);
            if (tb_DIVISION == null)
            {
                return HttpNotFound();
            }
            return View(tb_DIVISION);
        }

        // POST: tb_DIVISION/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DivisionID,DivisionName")] tb_DIVISION tb_DIVISION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_DIVISION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_DIVISION);
        }

        // GET: tb_DIVISION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DIVISION tb_DIVISION = db.tb_DIVISION.Find(id);
            if (tb_DIVISION == null)
            {
                return HttpNotFound();
            }
            return View(tb_DIVISION);
        }

        // POST: tb_DIVISION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_DIVISION tb_DIVISION = db.tb_DIVISION.Find(id);
            db.tb_DIVISION.Remove(tb_DIVISION);
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
