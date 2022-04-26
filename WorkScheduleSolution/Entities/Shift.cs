using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkScheduleSolution.Entities
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }

        [Required]
        public int PlacementContractID { get; set; }

        [Required]
        public PlacementContract PlacementContract { get; set; }

        [Required]
        public int DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Column(TypeName = "TINYINT")]
        [Required]
        public sbyte NumberOfEmployees { get; set; }

        [Column(TypeName = "BIT")]
        public bool Active { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string Notes{ get; set; }

        [Required]
        public ICollection<Schedule> Schedules { get; set; }
    }
}
