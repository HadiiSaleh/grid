using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class MachinesReservation
    {
        [Required]
        [Key]
        public int machResId { get; set; }

        [Required]
        [DisplayName("Machine Name")]
        public String machine_name { get; set; }

        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Required]
        [DisplayName("Reserved/not")]
        public int ResOrNot { get; set; }

        [Required]
        [DisplayName("Experiment ID")]
        public int ex_id { get; set; }


        [ForeignKey("ex_id")]
        public virtual Experiment Experiment { get; set; }
    }
}
