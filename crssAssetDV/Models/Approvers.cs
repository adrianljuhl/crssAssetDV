using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace crssAssetDV.Models
{
    public class Approvers
    {

    public int Id { get; set; }
    public People People { get; set; }

    }
}