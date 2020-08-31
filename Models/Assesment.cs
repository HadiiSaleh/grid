using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class Assesment
    {
        [DisplayName("Assesment Id")]
        public int Id { get; set; }


        [DisplayName("Trainee Name")]
        public string TraineeName { get; set; }


        [DisplayName("Student Name")]
        public string StudentName { get; set; }


        [DisplayName("Quality")]
        public int quality { get; set; }


        [DisplayName("Quantity")]
        public int quantity { get; set; }


        [DisplayName("Work Habits")]
        public int work_habits { get; set; }


        [DisplayName("Communication")]
        public int communication { get; set; }


        [DisplayName("Attitude")]
        public int attitude { get; set; }


        [DisplayName("Professionalism")]
        public int professionalism { get; set; }


        [DisplayName("Leadership")]
        public int leadership { get; set; }


        [ForeignKey("User_Id")]
        public int User_Id { get; set; }

        public virtual User User { get; set; }
    }
}
