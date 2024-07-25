using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MVCApp.Models.Db;
using MVCapp.Models.Db.Entity;
using System;
using System.Threading.Tasks;

namespace MVCapp.Models.Db.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            var entity = _context.Entry(user);
            if (entity.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

        }
        public async Task<User[]> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }
    }
}
