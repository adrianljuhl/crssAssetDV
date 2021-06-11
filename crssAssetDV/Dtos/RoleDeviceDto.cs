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
    public class RoleDeviceDto
    {

        public int Id { get; set; }
        public string Role { get; set; }
    }   
}