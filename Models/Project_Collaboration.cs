using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class Project_Collaboration
    {
        public int ID { get; set; }
        [ForeignKey("project_id")]
        public int project_id { get; set; }
        [ForeignKey("collaboration_id")]
        public int collaboration_id { get; set; }

        public virtual Project Project { get; set; }
        public virtual Collaboration Collaboration { get; set; }
    }
}
