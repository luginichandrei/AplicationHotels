using System;

namespace Models
{
    public class BookedDays
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PeriodWithStatus Status { get; set; }
    }
}