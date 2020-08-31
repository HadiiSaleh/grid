using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class Biowaste
    {
        [DisplayName(" Id:")]
        public int Id { set; get; }


        [ForeignKey("Comp_Id")]
        public int Comp_Id { get; set; }
        public virtual Company Company { get; set; }


        [DisplayName("Box Number:")]
        public int Box_num { set; get; }

        [DisplayName(" weight:")]
        public int weight { set; get; }

        public ICollection<Experiment> Experiments { get; set; }
    }
}
