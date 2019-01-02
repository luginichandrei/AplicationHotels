using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{


    public class RoomService
    {
        RoomRepository useRoomRepo = new RoomRepository();

        public virtual List<BookedDays> GetBookedDays( DateTime startTime, DateTime endTime, string hotelName, int roomNumber)
        {

            var rezervedDays = useRoomRepo.GetRezervedDays(hotelName, roomNumber);

            var result = new List<BookedDays>();
            var sd = startTime;
            
                foreach (var rd in rezervedDays)
                {
                       result.Add(
                       new BookedDays(){
                       StartDate = sd,
                       EndDate = rd.StartDate.AddDays(-1),
                           Status = Enum.GetName(typeof(PeriodWithStatus), PeriodWithStatus.FreePeriod)
                       });

                       result.Add(
                       new BookedDays()
                       {
                           StartDate = rd.StartDate,
                           EndDate = rd.EndDate,
                           Status = Enum.GetName(typeof(PeriodWithStatus), PeriodWithStatus.ReservedPeriod)
                       });
                sd = rd.EndDate.AddDays(1);
                }
            return result;
        }

        public virtual List<TopRoom> GetRoomRating(DateTime startTime, DateTime endTime, string hotelName)
        {
            var rooms = useRoomRepo.GetRoomsRating(hotelName);

            var result = new List<TopRoom>();
            foreach (var ms in rooms)
            {
                result.Add(new TopRoom()
                {
                    RoomNumber = ms.RoomNumber,
                    HotelName = ms.HotelName,
                    CountRezerve = rooms.Where(x => x.RoomNumber == ms.RoomNumber).Count()
                });
            }
            return result.GroupBy(x => x.RoomNumber).Select(y => y.First()).OrderByDescending(x => x.CountRezerve).Take(10).ToList(); 
        }
    }
}
