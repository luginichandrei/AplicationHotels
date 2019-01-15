using Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IRezervationService : IService<Rezervation>
    {
        List<BookedDays> GetBookedDays(DateTime start, DateTime end, int roomid);
    }
}