using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using crssAssetDV.Models;

namespace crssAssetDV.ViewModels
{
    public class LoanNoteViewModel
    {
        public List<LoanType> LoanTypes { get; set; }
        public List<People> Peoples { get; set; }
        public List<Device> Devices { get; set; }
        
        //public IEnumerable<Loan> Loans { get; set; }
        public IEnumerable<LoanNote> LoanNotes { get; set; }
        
      
        public Loan Loans{ get; set; }


    }
}