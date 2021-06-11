using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crssAssetDV.Models
{
    public class RepairNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Date of Repair")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RepairDate { get; set; }

        [Display(Name = "Contract Number")]
        public int LoadId { get; set; }
        public Loan Loan { get; set; }

        [Display(Name = "EdQuip Number")]
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        
        [Display(Name = "Person")]
        public int PeopleId { get; set; }
        public People People { get; set; }

        [Display (Name = "Comment")]
        public string Comment { get; set; }
        

        [Display (Name = "Repair Type")]
        public int RepairTypeId { get; set; }
        public RepairType RepairType { get; set; }

        [Display (Name = "Warranty Repair?")]
        public bool WarrantyRepair { get; set; }

        [Display(Name = "Repair Cost")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public decimal RepairCost { get; set; }

    }   
}