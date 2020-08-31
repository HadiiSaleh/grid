using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class MeetingRR
    {
        [Required]
        [Key]
        public int mrrId { get; set; }

        [Required]
        [DisplayName("Hour")]
        public String hour { get; set; }

        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Required]
        [DisplayName("Objective")]
        public String objective { get; set; }

        [Required]
        [DisplayName("Summary")]
        public String summary { get; set; }

        [Required]
        [DisplayName("User ID")]
        public int id { get; set; }

        [ForeignKey("id")]
        public virtual User user { get; set; }

        public virtual ICollection<MeetingRR> MeetingRRs { get; set; }
    }
}
