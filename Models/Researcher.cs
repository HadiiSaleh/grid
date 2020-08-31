using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class Researcher
    {
        [Required]
        [Key]
        public int rid { get; set; }

        [Required]
        [DisplayName("Reseacher Name")]
        public String reseacher_name { get; set; }

        public virtual ICollection<Project_Researcher> Project_Researchers { get; set; }
    }
}
