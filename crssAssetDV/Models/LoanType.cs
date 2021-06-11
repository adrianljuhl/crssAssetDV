using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crssAssetDV.Models
{
    public class LoanType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Display(Name = "Type of Loan")]
        public string Type { get; set; }
        
    }
}