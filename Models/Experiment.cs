using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class Experiment
    {
        [Key]
        [DisplayName("Experiment Id")]
        public int Exp_Id { get; set; }

        [ForeignKey("Id")]
        public int Id { get; set; }
        public virtual Biowaste biowaste { get; set; }


        [DisplayName("Project")]
        public String Project { get; set; }

        [DisplayName("Supervisor")]
        public int Superv { get; set; }

        [DisplayName("Description")]
        public int Desc { get; set; }

        public ICollection<MachinesReservation> MachinesReservations { get; set; }

        public ICollection<RequiredMaterial> RequiredMaterials { get; set; }
        public ICollection<ConsumedMaterials> ConsumedMaterials { get; set; }
    }
}
