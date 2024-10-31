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
    public class tb_EMPLOYEEController : Controller
    {
        private Manage db = new Manage();

        // GET: tb_EMPLOYEE
        public ActionResult Index()
        {
            var tb_EMPLOYEE = db.tb_EMPLOYEE.Include(t => t.tb_DEPARTMENT).Include(t => t.tb_DIVISION).Include(t => t.tb_EDUCATION).Include(t => t.tb_POSITION);
            return View(tb_EMPLOYEE.ToList());
        }

        // GET: tb_EMPLOYEE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_EMPLOYEE tb_EMPLOYEE = db.tb_EMPLOYEE.Find(id);
            if (tb_EMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(tb_EMPLOYEE);
        }

        // GET: tb_EMPLOYEE/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.tb_DEPARTMENT, "DepartmentID", "DepartmentName");
            ViewBag.DivisionID = new SelectList(db.tb_DIVISION, "DivisionID", "DivisionName");
            ViewBag.EducationID = new SelectList(db.tb_EDUCATION, "EducationID", "EducationName");
            ViewBag.PositionID = new SelectList(db.tb_POSITION, "PositionID", "PositionName");
            return View();
        }

        // POST: tb_EMPLOYEE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,FullName,Gender,DateOfBirth,PhoneNumber,IdentityCard,Address,ProfilePicture,DepartmentID,DivisionID,PositionID,EducationID")] tb_EMPLOYEE tb_EMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.tb_EMPLOYEE.Add(tb_EMPLOYEE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.tb_DEPARTMENT, "DepartmentID", "DepartmentName", tb_EMPLOYEE.DepartmentID);
            ViewBag.DivisionID = new SelectList(db.tb_DIVISION, "DivisionID", "DivisionName", tb_EMPLOYEE.DivisionID);
            ViewBag.EducationID = new SelectList(db.tb_EDUCATION, "EducationID", "EducationName", tb_EMPLOYEE.EducationID);
            ViewBag.PositionID = new SelectList(db.tb_POSITION, "PositionID", "PositionName", tb_EMPLOYEE.PositionID);
            return View(tb_EMPLOYEE);
        }

        // GET: tb_EMPLOYEE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_EMPLOYEE tb_EMPLOYEE = db.tb_EMPLOYEE.Find(id);
            if (tb_EMPLOYEE == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.tb_DEPARTMENT, "DepartmentID", "DepartmentName", tb_EMPLOYEE.DepartmentID);
            ViewBag.DivisionID = new SelectList(db.tb_DIVISION, "DivisionID", "DivisionName", tb_EMPLOYEE.DivisionID);
            ViewBag.EducationID = new SelectList(db.tb_EDUCATION, "EducationID", "EducationName", tb_EMPLOYEE.EducationID);
            ViewBag.PositionID = new SelectList(db.tb_POSITION, "PositionID", "PositionName", tb_EMPLOYEE.PositionID);
            return View(tb_EMPLOYEE);
        }

        // POST: tb_EMPLOYEE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,FullName,Gender,DateOfBirth,PhoneNumber,IdentityCard,Address,ProfilePicture,DepartmentID,DivisionID,PositionID,EducationID")] tb_EMPLOYEE tb_EMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_EMPLOYEE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.tb_DEPARTMENT, "DepartmentID", "DepartmentName", tb_EMPLOYEE.DepartmentID);
            ViewBag.DivisionID = new SelectList(db.tb_DIVISION, "DivisionID", "DivisionName", tb_EMPLOYEE.DivisionID);
            ViewBag.EducationID = new SelectList(db.tb_EDUCATION, "EducationID", "EducationName", tb_EMPLOYEE.EducationID);
            ViewBag.PositionID = new SelectList(db.tb_POSITION, "PositionID", "PositionName", tb_EMPLOYEE.PositionID);
            return View(tb_EMPLOYEE);
        }

        // GET: tb_EMPLOYEE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_EMPLOYEE tb_EMPLOYEE = db.tb_EMPLOYEE.Find(id);
            if (tb_EMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(tb_EMPLOYEE);
        }

        // POST: tb_EMPLOYEE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_EMPLOYEE tb_EMPLOYEE = db.tb_EMPLOYEE.Find(id);
            db.tb_EMPLOYEE.Remove(tb_EMPLOYEE);
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
