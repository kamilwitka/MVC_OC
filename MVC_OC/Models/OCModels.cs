using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OC.Models
{
    [Table("OC")]
    public class OCModels
    {
        [Key]
        public string OC_ID { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Descripton { get; set; }
        [StringLength(100)]
        public string CarModel { get; set; }
        
    }
}