using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkScheduleSolution.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        [Required]
        public string LastName { get; set; }

        [Column(TypeName = "CHAR(12)")]
        [Required]
        public string HomePhone { get; set; }

        [Column(TypeName = "BIT")]
        public bool Active { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
