using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemTechTask.Models;

namespace SystemTechTask.Controllers
{
    public class HomeController : Controller
    {
        SystemTechContext db = new SystemTechContext();
        public ActionResult Index()
        {
            CompanyViewModel model = new CompanyViewModel()
            {
                Employees = db.Employees.ToList(),
                Departments = db.Departments.ToList()
            };
            return View(model);
        }
    }
}