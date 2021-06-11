using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using crssAssetDV.Models;

namespace crssAssetDV.ViewModels
{
    public class DeviceFormViewModel
    {
        public IEnumerable<TypeOfDevice> TypeOfDevices { get; set; }
        public IEnumerable<RoleDevice> RoleDevices { get; set; }
        public IEnumerable<DamagedSelectOption> DamagedSelectOptions { get; set; }
        public IEnumerable<Loan> Loans { get; set; }
        public IEnumerable<DeviceNote> DeviceNotes { get; set; }

        //public IEnumerable<Device> Devices { get; set; }
        public Device Devices { get; set; }
    }
}