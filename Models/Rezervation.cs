using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Rezervation
    {
        public int Id { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public int UserId { get; set; }
        public Users Users { get; set; }
        public int RoomId { get; set; }
        public Room Rooms { get; set; }
    }
}
