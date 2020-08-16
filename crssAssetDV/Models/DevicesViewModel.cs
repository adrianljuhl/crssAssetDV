using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crssAssetDV.Models
{
    public class DevicesViewModel
    {
        public decimal Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Edquip { get; set; }
        public string Serial { get; set; }
        public string SpecialisedDevice { get; set; }
        public string BuildingLocation { get; set; }
        public string HasPowerSupply { get; set; }
        public string HasPowerCable { get; set; }
        public string HasCover { get; set; }
        public string Accessories { get; set; }
        public DeviceNotes DeviceNotes { get; set; }
        public bool WriteOff { get; set; }
        public string TypeOfDevice { get; internal set; }
    }
}