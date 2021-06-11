using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crssAssetDV.Models
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Display(Name = "StartDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }
        
        [Display(Name = "ReturnDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "Person")]
        [Required]
        public int PeopleId { get; set; }
        public People People { get; set; }

        [Display(Name = "Device")]
        [Required]
        public int DeviceId { get; set; }
        public Device Device { get; set; }

        //[ForeignKey("LoanType")]
        [Display(Name = "Type Of Loan")]
        public int? LoanTypeId  { get; set; }
        public LoanType LoanType { get; set; }
       
        [Display(Name = "Class Name")]
        public string Classroom { get; set; }

        [Display(Name = "Special Note")]
        public string SpecialNote { get; set; }
      
        [Display(Name = "Supplied Cable")]
        public bool SuppliedCable { get; set; }

        [Display(Name = "Supplied Cover")]
        public bool SuppliedCover { get; set; }

        [Display(Name = "Supplied Power")]
        public bool SuppliedPowerBlock { get; set; }

        [Display(Name = "OAMPS Updated (If CFT)")]
        public bool OampsUpdated { get; set; }
        
        [Display(Name = "Intune Updated")]
        public bool IntuneUpdated { get; set; }

        [Display(Name = "Edquip Signed")]
        [Required]
        public bool EdquipSigned { get; set; }

        [Display(Name = "Current")]
        public bool Current { get; set; }

    }
}