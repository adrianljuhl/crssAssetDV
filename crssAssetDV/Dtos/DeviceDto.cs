using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using crssAssetDV.Models;

namespace crssAssetDV.Dtos
{
    public class DeviceDto
    {
 
        public int Id { get; set; }

       
        public int TypeOfDeviceId { get; set; }
        public TypeOfDeviceDto TypeOfDevice { get; set; }

        public string Edquip { get; set; }
        public string Serial { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        
        public int RoleDeviceId { get; set; }
        public RoleDeviceDto RoleDevice { get; set; }
               
        public string BuildingLocation { get; set; }

        public string Accessories { get; set; }

        public int DamagedRefId { get; set; }
        public DamagedSelectOptionDto DamagedSelectOption { get; set; }

        public bool WriteOff { get; set; }

        public int? DeviceNoteId { get; set; }
        public DeviceNote DeviceNote { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Warranty To")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? WarrantyTo { get; set; }


        [Display(Name = "Write Off Date")]
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

    }
}