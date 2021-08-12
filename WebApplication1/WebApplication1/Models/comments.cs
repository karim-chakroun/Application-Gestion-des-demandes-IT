using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class comments
    {
        [Key]
        public int? commentId { get; set; }
        public string content { get; set; }
        public string userName { get; set; }
        public int RequestsId { get; set; }

        public requests Requests { get; set; }

    }
}
