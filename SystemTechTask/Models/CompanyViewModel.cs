using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemTechTask.Models
{
    public class CompanyViewModel
    {
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}