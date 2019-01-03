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
        
        private readonly ClientDbContext roomContext;

        public RoomService(ClientDbContext roomContext)
        {
            this.roomContext = roomContext;
        }

        public Room Create(Room entity)
        {
             roomContext.Set<Room>().Add(entity);
             roomContext.SaveChanges();
             return entity;
        }

        public Room Update(Room entity)
        {
            var local = roomContext.Set<Room>()
                        .Local.FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            roomContext.Entry(local).State = EntityState.Detached;
            roomContext.Entry(entity).State = EntityState.Modified;
            roomContext.SaveChanges();
            return entity;
        }
        
        public Room Delete(Room entity)
        {
            roomContext.Set<Room>().Attach(entity);
            roomContext.Entry(entity).State = EntityState.Deleted;            
            roomContext.SaveChanges();
            return entity;
        }

        public Room GetById(int id)
        {
           return roomContext.Set<Room>().Find(id);
        }

        public Hotel FindByName(string name)
        {
            return roomContext.Hotels.Where(x => x.Name == name).Single();
        }

        public Room FindByNumber(int number)
        {
            return roomContext.Set<Room>().Where(x=> x.Number==number).Single();
        }
        public IQueryable<Room> GetAll()
        {
           return roomContext.Rooms.AsNoTracking();
        }
        

        public List<Rezervation> GetByHotelId(int hotelId)
        {
           var rooms = roomContext.Rezervations
               .Include(x=> x.Rooms)
                   .Where(x=> x.Rooms.HotelId==hotelId && x.RoomId==x.Rooms.Id)
                .AsNoTracking()
                .ToList();
           return rooms;
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
