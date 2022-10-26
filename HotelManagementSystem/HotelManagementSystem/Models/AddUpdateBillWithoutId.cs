using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class AddUpdateBillWithoutId
    {
        [Required]
        public float Bill_Amount { get; set; }
        [Required]
        public string Bill_Date { get; set; }
    }
}
