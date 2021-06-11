using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;
namespace crssAssetDV.Models
{
    public class DeviceNoteDto
    {
        public int Id { get; set; }
        public string Note { get; set; }

        
        

    }
}