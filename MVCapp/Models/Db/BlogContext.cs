using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MVCapp.Models.Db.Entity;

namespace MVCApp.Models.Db
{
    public class BlogContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> UserPost { get; set; }
        public DbSet<Request> Requests { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
