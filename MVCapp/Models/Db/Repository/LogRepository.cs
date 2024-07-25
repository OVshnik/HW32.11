using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MVCApp.Models.Db;
using MVCapp.Models.Db.Entity;
using System;
using System.Threading.Tasks;

namespace MVCapp.Models.Db.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly BlogContext _context;

        public LogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddRequest(Request request)
        {
            request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();

            var entity = _context.Entry(request);
            if (entity.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            await _context.SaveChangesAsync();

        }
        public async Task<Request[]> GetRequests()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}
