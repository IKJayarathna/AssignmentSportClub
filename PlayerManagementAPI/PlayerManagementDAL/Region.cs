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
    public class Region
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
    
    }

}
