﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelManagementSystem.Models
{
    public class AddUpdateReservationWithoutId:IValidatableObject
    {
        [Required]
        public string Resevation_Check_In { get; set; }
        [Required]
        public string Resevation_Check_Out { get; set; }
        [Required]
        public int Reservation_No_of_Guests { get; set; }

        [Required]
        public Boolean Reservation_Status { get; set; }
        public int Guest_Id { get; set; }

        public int Room_Id { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int result1 = DateTime.Compare(DateTime.Parse(Resevation_Check_In), DateTime.Now);
            int result2 = DateTime.Compare(DateTime.Parse(Resevation_Check_Out), DateTime.Today);
            if (result1 < 0)
            {
                yield return new ValidationResult("Please Enter a valid Checkin Date");
            }
            if (result2 <= 0)
            {
                yield return new ValidationResult("Please Enter a valid Checkout Date");
            }

        }

    }
}
