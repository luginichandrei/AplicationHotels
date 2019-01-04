using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class RoomService
    {
        private readonly ClientDbContext context;

        public RoomService(ClientDbContext context)
        {
            this.context = context;
        }

        public Room Create(Room entity)
        {
            context.Rooms.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public Room Update(Room entity)
        {
            var local = context.Rooms
                        .Local.FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            context.Entry(local).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public Room Delete(Room entity)
        {
            context.Rooms.Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
            return entity;
        }

        public Room GetById(int id)
        {
            return context.Rooms.Find(id);
        }

        public Room FindByNumber(int number)
        {
            return context.Rooms.Where(x => x.Number == number).Single();
        }

        public virtual IQueryable<Room> GetAll()
        {
            return context.Rooms.AsNoTracking();
        }

        public List<RezervedDays> GetRezervedDays(int hotelId, int roomId)
        {
            var result = new List<RezervedDays>();

            //var days = roomContext.Rezervations.Contains(roomId);

            return result;
        }

        public List<BookedDays> GetBookedDay(int hotelId, int roomId)
        {
            var result = new List<BookedDays>();
            var rezervedDays = GetRezervedDays(hotelId, roomId);

            return result;
        }

        private RoomRepository useRoomRepo = new RoomRepository();

        public virtual List<BookedDays> GetBookedDays(DateTime startTime, DateTime endTime, string hotelName, int roomNumber)
        {
            var rezervedDays = useRoomRepo.GetRezervedDays(hotelName, roomNumber);
            var result = new List<BookedDays>();
            var sd = startTime;

            foreach (var rd in rezervedDays)
            {
                result.Add(
                new BookedDays()
                {
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