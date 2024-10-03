using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodWagon.Models
{
    public class RegisterationDetailcontext : DbContext
    {
        public RegisterationDetailcontext(DbContextOptions<RegisterationDetailcontext> options) : base(options) { }
        public DbSet<Registeration> Registeration {  get; set; }    
    }
}

