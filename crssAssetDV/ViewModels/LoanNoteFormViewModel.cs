using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using crssAssetDV.Models;

namespace crssAssetDV.ViewModels
{
    public class LoanNoteFormViewModel
    {
        public List<LoanType> LoanTypes { get; set; }
        public List<People> Peoples { get; set; }
        public List<Device> Devices { get; set; }
        public List<LoanNote> LoanNote { get; set; }
        public Loan Loan { get; set; }
    }
}