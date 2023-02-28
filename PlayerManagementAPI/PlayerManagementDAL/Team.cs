using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerManagementDAL
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }

        [ForeignKey("Ground")]
        public int GroundId { get; set; }

        [ForeignKey("Coach")]
        public int CoachId { get; set; }
        public int FoundedYear { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }

        [ForeignKey("RugbyUnion")]
        public int RugbyUnionId { get; set; }

        
        public Coach Coach { get; set; }        
        public Region Region { get; set; }               
        public Ground Ground { get; set; }                
        public RugbyUnion RugbyUnion { get; set; }
    }
}
