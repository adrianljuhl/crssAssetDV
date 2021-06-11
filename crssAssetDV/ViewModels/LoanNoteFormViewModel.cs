using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using crssAssetDV.Models;

namespace crssAssetDV.ViewModels
{
    public class LoanNoteFormViewModel
    {
        public IEnumerable<Loan> Loans { get; set; }        
        public LoanNote LoanNote { get; set; }
    }
}