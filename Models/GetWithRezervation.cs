using System;

namespace Models
{
    public class RoomsWithRezervation
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public int ComfortLevel { get; set; }
        public int Capability { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
    }
}