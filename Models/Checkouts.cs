using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Checkouts
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int UserId { get; set; }
        public Users Users { get; set; }
        public int RoomId { get; set; }
        public Room Rooms { get; set; }
    }
}
