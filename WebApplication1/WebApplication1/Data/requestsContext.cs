using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class requestsContext : DbContext
    {
        public requestsContext (DbContextOptions<requestsContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.requests> requests { get; set; }

        public DbSet<WebApplication1.Models.comments> comments { get; set; }
    }
}
