using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class Project
    {
        [Required]
        [Key]
        public int proj_id { get; set; }


        [Required]
        [DisplayName("Funding Organism")]
        public String funding_organism { get; set; }

        [Required]
        [DisplayName("Funding Duration")]
        public String funding_duration { get; set; }

        [Required]
        [DisplayName("Fund Amount")]
        public String fund_amount { get; set; }

        [Required]
        [DisplayName("From")]
        public String from { get; set; }

        [Required]
        [DisplayName("To")]
        public String to { get; set; }

        [Required]
        [DisplayName("Reasearch Assistant Fees")]
        public String reasearchAssistantFees { get; set; }

        [Required]
        [DisplayName("Congress")]
        public int congress { get; set; }

        [Required]
        [DisplayName("Field Fees")]
        public int fieldFees { get; set; }

        [Required]
        [DisplayName("Publication and Patent Fees")]
        public int publicationAndPatentFees { get; set; }

        [Required]
        [DisplayName("Consumables")]
        public int consumables { get; set; }

        [Required]
        [DisplayName("Machines and Equipements")]
        public int machinesAndEquipements { get; set; }

        [Required]
        [DisplayName("Others")]
        public int others { get; set; }

        [Required]
        [DisplayName("User ID")]
        public int id { get; set; }

        [ForeignKey("id")]
        public virtual User user { get; set; }

        public virtual ICollection<ConsumedMaterials> ConsumedMaterials { get; set; }
        public virtual ICollection<Project_Collaboration> Project_Collaborations { get; set; }
        public virtual ICollection<Project_Researcher> Project_Researchers { get; set; }
    }
}
