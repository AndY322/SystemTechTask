using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemTechTask.Models;
using System.Data.Entity;

namespace SystemTechTask.Controllers
{
    public class EmployeeController : Controller
    {
        #region private Fields

        SystemTechContext db = new SystemTechContext();

        #endregion

        #region public Methods

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.departments = new SelectList(db.Departments.ToList(), "Id", "Name");
            ViewBag.positions = new SelectList(db.Positions.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return GetEmployeeView(employee);
            }
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var employee = db.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return GetEmployeeView(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return GetEmployeeView(employee);
            }
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var employee = db.Employees.FirstOrDefault(e => e.Id == id);
            if(employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            var employee = db.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region private Methods

        private ActionResult GetEmployeeView(Employee employee)
        {
            ViewBag.departments = new SelectList(db.Departments.ToList(), "Id", "Name");
            ViewBag.positions = new SelectList(db.Positions.ToList(), "Id", "Name");
            return View(employee);
        }

        #endregion
    }
}