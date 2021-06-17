using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

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

        public static implicit operator LoanNote(List<LoanNote> v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator LoanNote(DbSet<LoanNote> v)
        {
            throw new NotImplementedException();
        }
    }
}