using Microsoft.EntityFrameworkCore;
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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.NameTg).HasMaxLength(200).IsRequired();
                entity.Property(c => c.NameRu).HasMaxLength(200).IsRequired();
                entity.Property(c => c.Slug).HasMaxLength(200).IsRequired();

                // One-to-many: Category -> Articles (optional FK on Article)
                entity.HasMany(c => c.Articles)
                      .WithOne(a => a.Category)
                      .HasForeignKey(a => a.CategoryId)
                      .OnDelete(DeleteBehavior.SetNull);

                // Category -> News: у News нет навигационного свойства к Category, используем shadow FK
                entity.HasMany(c => c.News)
                      .WithOne()
                      .HasForeignKey("CategoryId")
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.TitleTg).HasMaxLength(300).IsRequired();
                entity.Property(a => a.TitleRu).HasMaxLength(300).IsRequired();
                entity.Property(a => a.Slug).HasMaxLength(200).IsRequired();
                entity.Property(a => a.ContentTg).IsRequired();
                entity.Property(a => a.ContentRu).IsRequired();
                entity.Property(a => a.ViewCount).HasDefaultValue(0);
            });

            // Дополнительная конфигурация для News (если потребуется) можно добавить здесь
        }
    }
}