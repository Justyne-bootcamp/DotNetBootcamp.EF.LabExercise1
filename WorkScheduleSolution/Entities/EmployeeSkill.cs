using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkScheduleSolution.Entities
{
    public class EmployeeSkill
    {
        [Key]
        public int EmployeeSkillId { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public int SkillID { get; set; }

        [Required]
        public Skill Skill { get; set; }

        [Required]
        public int Level { get; set; }

        public int? YearsOfExperience { get; set; }

        [Column(TypeName = "MONEY")]
        [Required]
        public int HourlyWage { get; set; }
    }
}
