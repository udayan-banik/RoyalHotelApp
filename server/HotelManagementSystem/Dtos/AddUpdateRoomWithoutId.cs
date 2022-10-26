using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Dtos
{
    public class AddUpdateRoomWithoutId
    {
        //[Required]
        public bool Room_Status { get; set; }
        public string Room_Comment { get; set; }
        public string Room_Inventory { get; set; }
        //[Required]
        public float Room_Price { get; set; }
    }
}
