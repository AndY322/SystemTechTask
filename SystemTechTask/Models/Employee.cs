using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SystemTechTask.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DateOfEmployment { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Display(Name = "Position")]
        public int? PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}