using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class ItemsInventory
    {
        [Required]
        [Key]
        public int iid { get; set; }

        [Required]
        [DisplayName("Item Name")]
        public String item_name { get; set; }

        [Required]
        [DisplayName("Quantity Micro")]
        public int quantity_micro { get; set; }

        [Required]
        [DisplayName("Quantity Mol")]
        public int quantity_mol { get; set; }

        [Required]
        [DisplayName("Quantity Cell")]
        public int quantity_cell { get; set; }

        [Required]
        [DisplayName("Quantity Myco")]
        public int quantity_myco { get; set; }

        [Required]
        [DisplayName("Quantity Storage")]
        public int quantity_storage { get; set; }

        [Required]
        [DisplayName("Quantity Refrig")]
        public int quantity_refrig { get; set; }

        [Required]
        [DisplayName("Quantity Meeting")]
        public int quantity_meeting { get; set; }

        [Required]
        [DisplayName("Total")]
        public int total { get; set; }

        [Required]
        [DisplayName("User ID")]
        public int id { get; set; }

        [ForeignKey("id")]
        public virtual User user { get; set; }

        [Required]
        [DisplayName("IncomingProduct ID")]
        public int pr_id { get; set; }

        [ForeignKey("pr_id")]
        public virtual IncomingProduct incomingProduct { get; set; }

        [Required]
        [DisplayName("RequiredMaterial ID")]
        public int reqmat_id { get; set; }

        [ForeignKey("reqmat_id")]
        public virtual RequiredMaterial requiredMaterial { get; set; }

        public virtual ICollection<MachinesTC> MachinesToTestAndCalibrate { get; set; }
    }
}
