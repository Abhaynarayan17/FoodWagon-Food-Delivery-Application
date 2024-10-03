using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodWagon.Models
{
    public class Registeration
    {
        
        [Column(TypeName = "nvarchar(20)")]
        public string RestaurantName { get; set; } = "";

        [Key]
        [Column(TypeName = "nvarchar(50)")]
        public string EmailID { get; set; } = "";

        [Column(TypeName = "nvarchar(50)")]
        public string SellerName { get; set; } = "";

        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; } = "";


        [Column(TypeName = "nvarchar(50)")]
        public string ConfirmPassword { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string RestaurantAddress { get; set; } = "";

        [Column(TypeName = "nvarchar(50)")]
        public string PhoneNumber { get; set; } = "";

        [Column(TypeName = "nvarchar(20)")]
        public string City { get; set; } = "";

        [Column(TypeName = "nvarchar(20)")]
        public string State { get; set; } = "";

        [Column(TypeName = "nvarchar(20)")]
        public string Pincode { get; set; } = "";


    }


}

