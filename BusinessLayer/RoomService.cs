using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer
{
    public class RoomService
    {
        public Room Create(Room entity)
        {
            using (var context = new ClientDbContext())
            {
                context.Set<Room>().Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public Room Update(Room entity)
        {
            using (var context = new ClientDbContext())
            {
                context.Set<Room>().Attach(entity);
                context.SaveChanges();
                return entity;
            }
        }
        
        public Room Delete(Room entity)
        {
            using (var context = new ClientDbContext())
            {
                context.Set<Room>().Attach(entity);
                context.Set<Room>().Remove(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public Room GetById(int id)
        {
            using (var context = new ClientDbContext())
            {
                return context.Set<Room>().Find(id);
            }
        }

        public IQueryable<Room> GetAll()
        {
            using(var context = new ClientDbContext()){
                return context.Rooms;
            }
        }

        public List<Rezervation> GetRezervedDays(int userId, int roomId)
        {
                using (var context = new ClientDbContext())
                {
                    var room = context.Rezervations                 
                    .Where(x=> x.RoomId==roomId && x.UserId==userId).ToList();
                return room;
                }
        }



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
