using Microsoft.EntityFrameworkCore;
using NewBlazorBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlazorBlog.Server.Data
{
    public class DataContext : DbContext
    {
        public  DataContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
