using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crssAssetDV.Models
{
    public class LoanNoteDto
    {

        public int Id { get; set; }
        public int LoanId { get; set; }
       
        public Loan Loan { get; set; }
        public string Note { get; set; }
    }
}
