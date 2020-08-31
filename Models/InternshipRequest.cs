using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class InternshipRequest
    {
        [Required]
        [Key]
        public int intr_id { get; set; }

        [Required]
        [DisplayName("Student id")]
        public int student_id { get; set; }

        [Required]
        [DisplayName("Phone numbre")]
        public String phone_number { get; set; }

        [Required]
        [DisplayName("Email")]
        public String email { get; set; }

        [Required]
        [DisplayName("Photo")]
        public String photo { get; set; }

        [Required]
        [DisplayName("Place")]
        public String place { get; set; }

        [Required]
        [DisplayName("Funding duration")]
        public String fundingDuration { get; set; }

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
