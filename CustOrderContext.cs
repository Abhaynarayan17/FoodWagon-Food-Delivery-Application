using Microsoft.EntityFrameworkCore;

namespace FoodWagon.Models
{
    public class CustOrderContext : DbContext
    {
        public CustOrderContext(DbContextOptions<CustOrderContext> options) : base(options) { }
        public DbSet<CustOrders> CustOrders { get; set; }
    }
}
