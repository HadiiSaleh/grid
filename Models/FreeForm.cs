using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class FreeForm
    {
        [Key]
        [DisplayName("Free Form Id")]
        public int ff_Id { get; set; }

        [ForeignKey("User_Id:")]
        public int User_Id { get; set; }
        public virtual User User { get; set; }


        [DisplayName("Acceptance:")]
        public int acceptance { get; set; }
    }
}
