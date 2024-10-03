using Microsoft.EntityFrameworkCore;

namespace FoodWagon.Models
{
    public class MenuContext : DbContext

    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        { 
        }
         public DbSet<Menu> Menus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .Property(m => m.FoodPrice)
                .HasPrecision(16, 2);

        }

    }

}

    


