using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using crssAssetDV.Models;

namespace crssAssetDV.ViewModels
{
    public class LoanFormViewModel
    {
        public IEnumerable<LoanType> LoanTypes { get; set; }
        public IEnumerable<People> Peoples { get; set; }
        public IEnumerable<Device> Devices { get; set; }
        public IEnumerable<LoanNote> LoanNotes { get; set; }

        public Loan Loan { get; set; }
    }
}