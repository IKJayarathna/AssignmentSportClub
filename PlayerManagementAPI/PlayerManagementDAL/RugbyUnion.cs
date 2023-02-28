using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerManagementDAL
{
    public class RugbyUnion
    {
        [Key]
        public int RugbyUnionId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
             
    }
}
