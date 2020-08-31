using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class OpeningAndClosing
    {
        [Required]
        [Key]
        public int oc_id { get; set; }

        [Required]
        [DisplayName("Opening Time")]
        [DataType(DataType.Time)]
        public DateTime opening_time { get; set; }

        [Required]
        [DisplayName("Closing Time")]
        [DataType(DataType.Time)]
        public DateTime closing_time { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public virtual ICollection<User_OpeningClosing> User_OpeningClosings { get; set; }
    }
}
