using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace crssAssetDV.Models
{
    public class Loans
    {
        public int Id { get; set; }
        public People People { get; set; }
        public Devices Devices { get; set; }
        public Approvers Approvers { get; set; }
        public string LoanType { get; set; }
        public string Location { get; set; }
        public string SuppliedPowerBlock { get; set; }
        public string SuppliedCable { get; set; }
        public string SuppliedCover { get; set; }
        public string oampsUpdated { get; set; }
        public string intuneUpdated { get; set; }
        public string edquipSigned { get; set; }
        

    }
}