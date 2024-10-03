using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWagon.Models
{
    public class Signup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName ="nvarchar(10)")]
        public int CustomerId { get; set; }


        [Column(TypeName = "nvarchar(20)")]
        public string CustomerName { get; set; } = "";


        [Column(TypeName = "nvarchar(50)")]
        public string EmailID { get; set; } = "";


        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; } = "";


        [Column(TypeName = "nvarchar(50)")]
        public string ConfirmPassword { get; set; } = "";


        [Column(TypeName = "nvarchar(50)")]
        public string PhoneNumber { get; set; } = "";


        [Column(TypeName = "nvarchar(100)")]
        public string CustomerAddress { get; set; } = "";


        [Column(TypeName = "nvarchar(20)")]
        public string City { get; set; } = "";


        [Column(TypeName = "nvarchar(20)")]
        public string State { get; set; } = "";



        [Column(TypeName = "nvarchar(20)")]
        public string Pincode { get; set; } = "";


    } 
         
    
}

