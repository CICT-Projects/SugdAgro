using Microsoft.EntityFrameworkCore;
using SugdAgro.API.Models;
using SugdAgro.Models; 

namespace SugdAgro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; }
        public DbSet<User> Users { get; set; }
    }
}