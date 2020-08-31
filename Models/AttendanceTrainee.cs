using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class AttendanceTrainee
    {
        [Key]
        [DisplayName("Trainee Id:")]
        public int Id { set; get; }


        [DisplayName("Arrival Time:")]
        [DataType(DataType.Time)]
        public DateTime Arrv_Time { set; get; }



        [DisplayName("Leaving Time:")]
        [DataType(DataType.Time)]
        public DateTime Leav_Time { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }


        [ForeignKey("User_Id")]
        public int User_Id { get; set; }

        public virtual User User { get; set; }
    }
}
