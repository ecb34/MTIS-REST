using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_MTIS.Models
{
    public class RestKey
    {
        [Key]
        public string Key { get; set; }
    }
}