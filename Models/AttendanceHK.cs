using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class AttendanceHK
    {

        [DisplayName("Attendance HouseKeeping Id")]
        public int Id { set; get; }


        [DisplayName("Hour 1")]
        [DataType(DataType.Time)]
        public DateTime Hour_1 { set; get; }



        [DisplayName("Hour 2")]
        [DataType(DataType.Time)]
        public DateTime Hour_2 { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        [ForeignKey("User_Id")]
        public int User_Id { get; set; }

        public virtual User User { get; set; }
    }
}
