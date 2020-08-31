using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class ConsumablesInventory
    {
        [Key]
        [DisplayName("Id:")]
        public int Id { get; set; }

        [DisplayName("Furniture Name")]
        public String Fur_Name { get; set; }

        public int Quantity_micro { get; set; }

        public int Quantity_mol { get; set; }

        public int Quantity_cell { get; set; }

        public int Quantity_myco { get; set; }

        public int Quantity_storage { get; set; }

        public int Quantity_Refrig { get; set; }

        public int Quantity_meeting { get; set; }

        [DisplayName("Total")]
        public int Total { get; set; }

        [ForeignKey("Req_Id")]
        public int Req_Id { get; set; }
        public virtual RequiredMaterial RequiredMaterial { get; set; }


        [ForeignKey("Pr_Id")]
        public int Pr_Id { get; set; }
        public virtual IncomingProduct IncomingProduct { get; set; }


        [ForeignKey("User_Id")]
        public int User_Id { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<MachinesTC> MachinesToTestAndCalibrate { get; set; }
    }
}
