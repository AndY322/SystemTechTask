using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SystemTechTask.Models
{
    public class SystemTechContext : DbContext
    {
        public SystemTechContext() : base("SystemTechnologies")
            {}
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}