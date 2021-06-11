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
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [Display(Name = "Type")]
        [Required]
        public int TypeOfDeviceId { get; set; }
        public TypeOfDevice TypeOfDevice { get; set; }

        public string Edquip { get; set; }
        public string Serial { get; set; }

        [Display(Name = "Role?")]
        [Required]
        public int RoleDeviceId { get; set; }
        public RoleDevice RoleDevice { get; set; }

        [Display(Name = "Building")]
        public string BuildingLocation { get; set; }

        [Display(Name = "Notes")]
        public string Accessories { get; set; }

        [ForeignKey("DamagedSelectOption")]
        [Display(Name = "Status")]
        [Required]
        public int DamagedRefId { get; set; }
        public DamagedSelectOption DamagedSelectOption { get; set; }       
        
        [Display (Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }
        
        [Display(Name = "Warranty To")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? WarrantyTo {get; set;}
       
        public bool WriteOff { get; set; }

        [Display (Name = "Write Off Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? WriteOffDate { get; set; }

        [Display(Name = "Asset Checked")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AssetChecked { get; set; }

        [Display(Name = "Apple Id Model")]
        public string AppleModelRef { get; set; }

        [Display(Name = "Capacity")]
        public string Capacity { get; set; }

        [Display(Name = "Device Note")]
        public int? DeviceNoteId { get; set; }
        public DeviceNote DeviceNote { get; set; }

    }

}