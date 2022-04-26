using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WorkScheduleSolution.Entities
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "BIT")]
        public bool RequiresTicket { get; set; }

        [Required]
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }

    }
}
