using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerManagementDAL
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        [Precision(6,2)]
        public decimal? Height { get; set; }

        [Precision(6, 2)]
        public decimal? Weight { get; set; }
        public string PlaceOfBirth { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public bool? Active { get; set; }
        
        public Team Team { get; set; }
    }
}
