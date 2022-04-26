using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkScheduleSolution.Entities
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }

        [Column(TypeName = "DATE")]
        [Required]
        public DateTime Day { get; set; }

        [Required]
        public int ShiftID { get; set; }

        [Required]
        public Shift Shift { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Column(TypeName = "MONEY")]
        [Required]
        public int HourlyWage { get; set; }

        [Column(TypeName = "BIT")]
        public bool Active { get; set; }
    }
}
