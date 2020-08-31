using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class MembershipRequest
    {
        [Required]
        [Key]
        public int mr_id { get; set; }

        [Required]
        [DisplayName("Signature")]
        public String signature { get; set; }


        [Required]
        [DisplayName("User ID")]
        public int id { get; set; }

        [ForeignKey("id")]
        public virtual User user { get; set; }
    }
}
