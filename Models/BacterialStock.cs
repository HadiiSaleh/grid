using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class BacterialStock
    {
        [Key]
        [DisplayName("Id:")]
        public int Id { set; get; }


        [DisplayName("Box Name:")]
        public String Box_Name { set; get; }


        [DisplayName("Bacteria Name:")]
        public String Bacteria_Name { set; get; }


        [DisplayName("x:")]
        public int x { set; get; }


        [DisplayName("y:")]
        public int y { set; get; }

        [ForeignKey("Con_Id")]
        public int Con_Id { get; set; }
        public virtual ConsumedMaterials ConsumedMaterials { get; set; }


        [ForeignKey("Pr_Id")]
        public int Pr_Id { get; set; }
        public virtual IncomingProduct IncomingProduct { get; set; }


        [ForeignKey("Req_Id")]
        public int Req_Id { get; set; }
        public virtual RequiredMaterial RequiredMaterial { get; set; }
    }
}
