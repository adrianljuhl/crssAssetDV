using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace crssAssetDV.Models
{
    public class People
    {
        public decimal Id { get; set; }
        public bool Staff { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Phone { get; set; }
    }
}