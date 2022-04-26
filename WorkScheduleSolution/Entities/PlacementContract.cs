using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkScheduleSolution.Entities
{
    public class PlacementContract
    {
        [Key]
        public int PlacementContractID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int LocationID { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]

        public ICollection<Shift> Shifts { get; set; }

    }
}
