using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FoodWagon.Models
{
    public class CustOrders
    {
        
            [Key]
            public int Id { get; set; }  // Assuming this is equivalent to CustomerId

            [MaxLength(100)]
            public string RestroEmailId { get; set; } = "";  // RestroEmailID

            [MaxLength(100)]
            public string CustEmailId { get; set; } = "";  // CustEmailID

            [MaxLength(15)]
            public string PhoneNumber { get; set; } = "";  // PhoneNumber, assuming phone number has a max length of 15

            [Precision(16, 2)]
            public decimal TotalAmt { get; set; }  // TotalAmt, with precision for currency

            [MaxLength(250)]
            public string CustomerAddress { get; set; } = "";  // CustomerAddress, with a reasonable max length

            public DateTime OrderDateTime { get; set; }  // OrderDateTime
        

    }
}
