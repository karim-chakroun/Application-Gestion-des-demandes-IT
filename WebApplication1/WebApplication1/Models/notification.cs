using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class notification
    {
        [Key]
        public int? notifId { get; set; }
        public string titre { get; set; }
        public string username { get; set; }
    }
}
