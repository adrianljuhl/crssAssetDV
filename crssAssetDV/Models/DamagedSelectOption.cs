using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace crssAssetDV.Models
{
    public class DamagedSelectOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Display(Name = "Damaged?")]
        public string Option { get; set; }
        public List<Device> Devices { get; set; }
    

    }
}