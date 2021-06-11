using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crssAssetDV.Models
{
    public class LoanNote
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Loan Number")]
        [Required]
        public int? LoanId { get; set; }
        public Loan Loan { get; set; }

        [Display(Name = "Loan Note")]
        public string Note { get; set; }
    }
}