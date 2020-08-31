using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class BorrowPermission
    {
        [DisplayName(" Id:")]
        public int ID { set; get; }

        [ForeignKey("User_Id")]
        public int User_Id { get; set; }
        public virtual User User { get; set; }


        [DisplayName(" Position:")]
        public String Pos { set; get; }

        [DisplayName(" Project Name:")]
        public String Pro_name { set; get; }

        [DisplayName("Borrowed Object:")]
        public String Borr_Object { set; get; }

        [DisplayName("Quantity:")]
        public int quantity { set; get; }

        [DisplayName("Return Date")]
        [DataType(DataType.Date)]
        public DateTime Return_Date { set; get; }

    }
}
