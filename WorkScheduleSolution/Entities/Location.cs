using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkScheduleSolution.Entities
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        [Required]
        public string Street { get; set; }

        [Column(TypeName = "NVARCHAR(30)")]
        [Required]
        public string City { get; set; }

        [Column(TypeName = "NCHAR(2)")]
        [Required]
        public string Province { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string Contract { get; set; }

        [Column(TypeName = "CHAR(12)")]
        [Required]
        public string Phone { get; set; }

        [Column(TypeName = "BIT")]
        public bool Active { get; set; }

        [Required]
        public ICollection<PlacementContract> PlacementContracts { get; set; }
    }
}
