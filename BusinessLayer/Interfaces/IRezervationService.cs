using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IRezervationService : IService<Rezervation>
    {
        List<BookedDays> GetBookedDay(DateTime start, DateTime end, int roomid);
    }
}
