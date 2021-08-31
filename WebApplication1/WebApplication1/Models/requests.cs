using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class requests
    {
        [Key]
        public int? RequestsId { get; set; }
        public string NameT { get; set; }
        public string Status { get; set; }
        public string DateT { get; set; }
        public string Description { get; set; }
        public string customer { get; set; }
        public string Priorite { get; set; }
        public string uEmail { get; set; }
        public string Agent { get; set; }
        public string PhotoFileName { get; set; }
        public ICollection<comments> Comments { get; set; }
    }
}
