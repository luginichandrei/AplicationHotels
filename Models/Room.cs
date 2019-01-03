using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public int ComfortLevel {get;set;}
        public int Capability { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }       
    }
}
