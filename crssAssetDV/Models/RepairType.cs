using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crssAssetDV.Models
{
    public class RepairType
    {
        public int Id { get; set; }
        
        [Display (Name = "Type of Repair")]
        public string Repair { get; set;}
    }
}