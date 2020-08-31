using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class Collaboration
    {

        [Key]
        [DisplayName("Id:")]
        public int Id { get; set; }

        [ForeignKey("User_Id:")]
        public int User_Id { get; set; }

        public virtual User User { get; set; }


        [DisplayName("Collaborator Name")]
        public String Col_name { get; set; }

        [DisplayName("Institute")]
        public String institute { get; set; }

        [DisplayName("Project Title")]
        public String proj_Title { get; set; }

        [DisplayName("Compounds")]
        public String Compounds { get; set; }

        [DisplayName("Position")]
        public String Position { get; set; }

        [DisplayName("Test")]
        public String Test { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        public virtual ICollection<Project_Collaboration> Project_Collaborations { get; set; }
    }
}
