using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string NameHotel { get; set; }
        public int FoundationYear { get; set; }
        public string Address { get; set; }
        public int IsActive { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModify { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}