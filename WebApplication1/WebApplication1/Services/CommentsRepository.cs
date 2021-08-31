using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly requestsContext requestsContext;

        public CommentsRepository(requestsContext requestsContext)
        {
            this.requestsContext = requestsContext;
        }

        public async Task<IEnumerable<comments>> Search(string content)
        {
            IQueryable<comments> query = requestsContext.comments;

            if (!string.IsNullOrEmpty(content))
            {
                query = query.Where(e => e.content.Contains(content)
                            );
            }
            return await query.ToListAsync();

        }
    }
}
