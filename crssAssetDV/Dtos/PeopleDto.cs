using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crssAssetDV.Dtos
{
    public class PeopleDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MIS { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
     
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        
        public bool OnLeave { get; set; }
        public bool Left { get; set; }



    }
}