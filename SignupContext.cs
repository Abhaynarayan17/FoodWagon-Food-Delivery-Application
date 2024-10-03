using Microsoft.EntityFrameworkCore;
namespace FoodWagon.Models
{
    public class SignupContext : DbContext
    {
        public SignupContext(DbContextOptions<SignupContext> options) : base(options)
            { }
        public DbSet<Signup> Signup { get; set; }
    }
}

