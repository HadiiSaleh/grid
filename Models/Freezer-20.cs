using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class Freezer_20
    {
        [Key]
        [DisplayName("Freezer20 Id:")]
        public int Id { get; set; }

        [ForeignKey("Con_Id:")]
        public int Con_Id { get; set; }
        public virtual ConsumedMaterials ConsumedMaterials { get; set; }


        [ForeignKey("Req_Id")]
        public int Req_Id { get; set; }
        public virtual RequiredMaterial RequiredMaterial { get; set; }


        [ForeignKey("Pr_Id")]
        public int Pr_Id { get; set; }
        public virtual IncomingProduct IncomingProduct { get; set; }


        [DisplayName("Box Name")]
        public String Box_Name { get; set; }

        [DisplayName("Box Type")]
        public String Box_Type { get; set; }

        [DisplayName("Level Number:")]
        public int Level_num { get; set; }

        [DisplayName("Side")]
        public String Side { get; set; }

        [DisplayName("Level within Side")]
        public String Lev_Side { get; set; }

        [DisplayName("Name Of Consumables")]
        public String Cons { get; set; }

    }
}
