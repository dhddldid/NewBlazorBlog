using Microsoft.EntityFrameworkCore;
using NewBlazorBlog.Shared;

namespace NewBlazorBlog.Server.Data
{
    public class DataContext : DbContext
    {
        public  DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
