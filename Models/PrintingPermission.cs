using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class PrintingPermission
    {
        [Required]
        [Key]
        public int printing_id { get; set; }


        [Required]
        [DisplayName("Page Number")]
        public int page_number { get; set; }

        [Required]
        [DisplayName("Colored Or Not")]
        public int coloredOrNot { get; set; }

        [Required]
        [DisplayName("User ID")]
        public int id { get; set; }

        [ForeignKey("id")]
        public virtual User user { get; set; }
    }
}
