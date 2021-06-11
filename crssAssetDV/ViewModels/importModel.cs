using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crssAssetDV.Models
{
    public class importModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        
        public double TypeOfDeviceId { get; set; }
        public string TypeOfDevice { get; set; }
        
        public string Description { get; set; }
        public string Edquip { get; set; }
        public string Serial { get; set; }
        
        public double RoleDeviceId { get; set; }
        public string RoleDevices { get; set; }
        
        public string BuildingLocation { get; set; }
        
        public double HasPowerSupplyRefId { get; set; }
        public string PowerSupplySelectOption { get; set; }
        
        public double HasPowerCableRefId { get; set; }
        public string CableSelectOption { get; set; }
        
        public double HasCoverRefId { get; set; }
        public string CoverSelectOption { get; set; }
        
        public string Accessories { get; set; }

        public double DamagedRefId { get; set; }
        public string DamagedSelectOption { get; set; }

        //public DeviceNotes DeviceNotes { get; set; }
        //public string DeviceNotes { get; set; }
        public bool WriteOff { get; set; }

       
        
        
        
    }
}