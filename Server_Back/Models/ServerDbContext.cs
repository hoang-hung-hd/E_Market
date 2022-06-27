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

            modelBuilder.Entity<ProductImageModel>().HasKey(table => new {
                table.ProductId,
                table.ImageId
            });
        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ImageModel> Images { set; get; }
        public DbSet<ProductImageModel> ProductImages { get; set; }
        
    }
}
