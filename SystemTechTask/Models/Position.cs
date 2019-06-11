using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemTechTask.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}