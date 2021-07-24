using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Ticket
    {
        [Key]
        public int? Id { get; set; }
        public string NameT { get; set; }
        public string Status { get; set; }
        public string DateT { get; set; }
        public string Description { get; set; }
        public string customer { get; set; }
        public string Agent { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }


    }
}
