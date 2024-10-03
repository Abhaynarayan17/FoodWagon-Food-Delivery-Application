using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FoodWagon.Models
{
    public class Menu
    {

            
        [Key]
        public int Id { get; set; }
        public int FoodId { get; set; }
        [MaxLength(100)]
        public string EmailId { get; set; } = "";
        [MaxLength(100)]
        public string FoodName { get; set; } = "";
        [Precision(16,2)]

        public decimal FoodPrice { get; set; }

        

       
        





    }

}

