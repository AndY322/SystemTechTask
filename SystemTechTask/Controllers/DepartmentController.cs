using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemTechTask.Models;
using System.Data.Entity;

namespace SystemTechTask.Controllers
{
    public class DepartmentController : Controller
    {
        #region private Fields

        SystemTechContext db = new SystemTechContext();

        #endregion

        #region public Methods

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.employees = new SelectList(db.Employees.Where(e => e.DepartmentId == null).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if(department.Name == null)
            {
                return Create(department);
            }
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var department = new Department();
            department = db.Departments.FirstOrDefault(d => d.Id == id);
            if(department == null)
            {
                return HttpNotFound();
            }
            ViewBag.employees = new SelectList(db.Employees.Where(e => e.DepartmentId == null).ToList(), "Id", "Name");
            department.Employees = db.Employees.Where(e => e.DepartmentId == id).ToList();
            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if(!ModelState.IsValid)
            {
                return Edit(department);
            }
            db.Entry(department).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetEmployeeTable(int? departmentId)
        {
            List<Employee> employees = new List<Employee>();
            if(departmentId != null)
            {
                employees = db.Employees.Where(e => e.DepartmentId == departmentId).ToList();
            }
            return PartialView(employees);
        }

        [HttpPost]
        public ActionResult AddEmployee(int? employeeId, int? departmentId, string name)
        {
            Employee employee = db.Employees.FirstOrDefault(e => e.Id == employeeId);
            employee.DepartmentId = departmentId;
            db.SaveChanges();
            return RedirectToAction("GetEmployeeTable", new { departmentId = employee.DepartmentId });
        }

        [HttpGet]
        public ActionResult AddEmployeeOnCreate(int? employeeId, string name)
        {
            Employee employee = db.Employees.FirstOrDefault(e => e.Id == employeeId);
            db.Departments.Add(new Department()
            {
                Name = name
            });
            db.SaveChanges();
            if (employee != null)
            {
                employee.DepartmentId = db.Departments.OrderByDescending(d => d.CreatedOn).FirstOrDefault().Id;
            }
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = employee.DepartmentId });
        }

        [HttpGet]
        public ActionResult RemoveFromDepartment(int? employeeId)
        {
            var employee = db.Employees.FirstOrDefault(e => e.Id == employeeId);
            if(employee == null)
            {
                return HttpNotFound();
            }
            var departmentId = employee.DepartmentId;
            employee.DepartmentId = null;
            db.SaveChanges();
            return RedirectToAction("Edit", new {id = departmentId });
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            var department = db.Departments.FirstOrDefault(d => d.Id == Id);
            if(department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            var department = db.Departments.FirstOrDefault(d => d.Id == id);
            foreach (var employee in department.Employees)
            {
                employee.DepartmentId = null;
            }
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}