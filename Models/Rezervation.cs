using System;

namespace Models
{
    public class Rezervation
    {
        public int Id { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public int UserId { get; set; }
        public User Users { get; set; }
        public int RoomId { get; set; }
        public Room Rooms { get; set; }
    }
}