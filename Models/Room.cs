using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Room: BaseDatatime
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public int ComfortLevel { get; set; }
        public int Capability { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        [JsonIgnore]
        public ICollection<Rezervation> Rezervation { get; set; }
    }
}
