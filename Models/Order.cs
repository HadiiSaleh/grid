using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicrobiologyLab.Models
{
    public class Order
    {
        [Required]
        [Key]
        public int ol_id { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public String product_name { get; set; }

        [Required]
        [DisplayName("Supervisor Name")]
        public String supervisor_name { get; set; }

        [Required]
        [DisplayName("Project Name")]
        public String project_name { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int quantity { get; set; }

        [Required]
        [DisplayName("Code")]
        public String code { get; set; }

        [Required]
        [DisplayName("Unit Price")]
        public String unit_price { get; set; }

        [Required]
        [DisplayName("Funding Duration")]
        public String funding_duration { get; set; }

        [Required]
        [DisplayName("Refrigeration Or Not")]
        public int refrigerationOrNot { get; set; }

        [Required]
        [DisplayName("Specifity Notes")]
        public String specifity_notes { get; set; }

        [Required]
        [DisplayName("Expiry Date")]
        [DataType(DataType.Date)]
        public DateTime expiry_date { get; set; }


        [Required]
        [DisplayName("Company Id")]
        public int comp_id { get; set; }

        [ForeignKey("comp_id")]
        public virtual Company company { get; set; }

        [Required]
        [DisplayName("User ID")]
        public int id { get; set; }

        [ForeignKey("id")]
        public virtual User user { get; set; }
    }
}
