using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class ConsumedMaterials
    {
        [Key]
        [DisplayName("Id:")]
        public int Con_Id { get; set; }

        [ForeignKey("Exp_Id")]
        public int Exp_Id { get; set; }
        public virtual Experiment Experiment { get; set; }


        [ForeignKey("Proj_Id")]
        public int Proj_Id { get; set; }
        public virtual Project Project { get; set; }


        [DisplayName("Name:")]
        public String name { get; set; }

        [DisplayName("Quantity:")]
        public int Quantity { get; set; }

        public virtual ICollection<RequiredMaterial> RequiredMaterials { get; set; }
    }
}
