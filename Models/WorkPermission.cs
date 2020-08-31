using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class WorkPermission
    {
        public int ID { get; set; }
        [ForeignKey("user")]
        public int user_id { get; set; }
        public string name { get; set; }
        public string work { get; set; }
        public string schedule { get; set; }
        public virtual User user { get; set; }
    }
}
