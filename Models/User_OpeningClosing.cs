using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class User_OpeningClosing
    {
        public int ID { get; set; }
        [ForeignKey("user_id")]
        public int project_id { get; set; }
        [ForeignKey("openindAndclosing_id")]
        public int openingclosing_id { get; set; }

        public virtual User User { get; set; }
        public virtual OpeningAndClosing OpeningAndClosing { get; set; }
    }
}
