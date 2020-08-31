using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class MachinesTC
    {
        [Required]
        [Key]
        public int mtcId { get; set; }

        [Required]
        [DisplayName("Machine Name")]
        public String name { get; set; }

        public virtual ICollection<TestingAndCalibration> TestingAndCalibrations { get; set; }

    }
}
