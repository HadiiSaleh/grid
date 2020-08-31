using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class IncomingProduct
    {
        [Required]
        [Key]
        public int pr_id { get; set; }

        [Required]
        [DisplayName("Name")]
        public String name { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int quantity { get; set; }

        [Required]
        [DisplayName("Weight")]
        public float weight { get; set; }

        [Required]
        [DisplayName("Expiry Date")]
        public DateTime exdate { get; set; }

        [Required]
        [DisplayName("Additionnal Notes")]
        public String additionnalNotes { get; set; }

        [Required]
        [DisplayName("Arriving Date")]
        public DateTime arrdate { get; set; }

        [Required]
        [DisplayName("User ID")]
        public int id { get; set; }

        [ForeignKey("id")]
        public virtual User user { get; set; }


        [Required]
        [DisplayName("Company Id")]
        public int comp_id { get; set; }

        [ForeignKey("comp_id")]
        public virtual Company company { get; set; }

        public virtual ICollection<OpeningAndClosing> OpeningAndClosings { get; set; }
        public virtual ICollection<ConsumablesInventory> Consumables { get; set; }
        public virtual ICollection<FurnituresInventory> Furnitures { get; set; }
        public virtual ICollection<ItemsInventory> Items { get; set; }
        public virtual ICollection<MachinesInventory> Machines { get; set; }

        public virtual ICollection<Freezer_20> Freezer_20s { get; set; }
        public virtual ICollection<BacterialStock> Bacterias { get; set; }
        public virtual ICollection<Freezer_80> Freezer_80s { get; set; }
    }
}
