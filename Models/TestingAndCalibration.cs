using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class TestingAndCalibration
    {
        public int ID { get; set; }
        [ForeignKey("machinetc")]
        public int mtc_id { get; set; }
        [ForeignKey("user")]
        public int user_id { get; set; }
        public string student_name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime next_check { get; set; }
        public virtual User user { get; set; }
        public virtual MachinesTC machinetc { get; set; }
    }
}
