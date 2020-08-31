using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class TrainingPreRegistration
    {
        [Key]
        public int tpr_id { get; set; }
        [ForeignKey("user")]
        public int user_id { get; set; }
        public string name { get; set; }
        public string speciality { get; set; }
        public string year { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        //requested training duration
        public string duration { get; set; }
        public virtual User user { get; set; }
    }
}
