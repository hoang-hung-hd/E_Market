using Microsoft.EntityFrameworkCore;

namespace Server_Back.Models
{
    public class ServerDbContext : DbContext
    {

        public ServerDbContext(DbContextOptions<ServerDbContext> option) :base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            modelBuilder.Entity<ProductImage>().HasKey(table => new {
                table.ProductId,
                table.ImageId
            });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { set; get; }
        public DbSet<ProductImage> ProductImages { get; set; }
        
    }
}
