using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class MeetingPresence
    {
        [Required]
        [Key]
        public int mpre_id { get; set; }

        [Required]
        [DisplayName("Name")]
        public String name { get; set; }

        [Required]
        [DisplayName("MeetingRR ID")]
        public int mrrId { get; set; }


        [ForeignKey("mrrId")]
        public virtual MeetingRR meetingRR { get; set; }
    }
}
