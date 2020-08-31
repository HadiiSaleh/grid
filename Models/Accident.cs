using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class Accident
    {
        [Key]

        [DisplayName("Accident Id:")]
        public int Id { get; set; }


        [ForeignKey("User_Id")]
        public int User_Id { get; set; }

        public virtual User User { get; set; }



        [DisplayName("Time")]
        [DataType(DataType.DateTime)]

        public DateTime time { get; set; }


        [DisplayName("Type")]
        public string type { get; set; }


        [DisplayName("Damages")]
        [DataType(DataType.MultilineText)]
        public string damages { get; set; }
    }
}
