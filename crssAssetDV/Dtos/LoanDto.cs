using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crssAssetDV.Dtos
{
    public class LoanDto
    {
 
        public int Id { get; set; }
        
        public DateTime? StartDate { get; set; }
               
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReturnDate { get; set; }

        public int PeopleId { get; set; }
        public PeopleDto People { get; set; }

        public int DeviceId { get; set; }
        public DeviceDto Device { get; set; }


        public int LoanTypeId { get; set; }
        public LoanTypeDto LoanType { get; set; }



        public string Classroom { get; set; }

        public string SpecialNote { get; set; }
      
   
        public bool SuppliedCable { get; set; }

    
        public bool SuppliedCover { get; set; }

      
        public bool SuppliedPowerBlock { get; set; }

    
        public bool OampsUpdated { get; set; }
        
      
        public bool IntuneUpdated { get; set; }


        public bool EdquipSigned { get; set; }

        public bool Current { get; set; }
    }
}