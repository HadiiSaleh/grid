using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class RequiredMaterial
    {
        [Required]
        [Key]
        public int reqmat_id { get; set; }

        [Required]
        [DisplayName("Name")]
        public String name1 { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int quantity { get; set; }

        [Required]
        [DisplayName("Experiment ID")]
        public int ex_id { get; set; }


        [ForeignKey("ex_id")]
        public virtual Experiment Experiment { get; set; }

        public virtual ICollection<ConsumablesInventory> Consumables { get; set; }
        public virtual ICollection<FurnituresInventory> Furnitures { get; set; }
        public virtual ICollection<ItemsInventory> Items { get; set; }

        public virtual ICollection<Freezer_20> Freezer_20s { get; set; }
        public virtual ICollection<BacterialStock> Bacterias { get; set; }
        public virtual ICollection<Freezer_80> Freezer_80s { get; set; }
    }
}
