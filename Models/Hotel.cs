using System;
using System.Collections.Generic;

namespace Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FoundationYear { get; set; }
        public string Address { get; set; }
        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}