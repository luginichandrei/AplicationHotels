﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class RoomRating
    {
        public int RoomNumber { get; set; }
        public string HotelName { get; set; }
        public List<RezervedDays> Days { get; set; }
    }
}