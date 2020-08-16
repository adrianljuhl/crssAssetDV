using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crssAssetDV.Models
{
    public class Devices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public TypeOfDevice TypeOfDevice { get; set; }
        public string Description { get; set; }
        public string Edquip { get; set; }
        public string Serial { get; set; }
        [Display (Name = "Specialised Device?")]
        public string SpecialisedDevice { get; set; }
        [Display(Name = "Building")]
        public string BuildingLocation { get; set; }
        [Display (Name = "Power?")]
        public string HasPowerSupply { get; set; }
        [Display (Name ="Cable?")]
        public string HasPowerCable { get; set; }
        [Display (Name ="Cover?")]
        public string HasCover { get; set; }
        public string Accessories { get; set; }
        public string Damaged { get; set; }
        [Display (Name ="Notes")]
        public DeviceNotes DeviceNotes { get; set; }
        public bool WriteOff { get; set; }  
    
        
    }

}