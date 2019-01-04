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

        public Room Delete(int id)
        {
            var entity = new Room() { Id = id };
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

        public List<RoomRating> GetRoomsRating(int hotelId)
        {
            var result = new List<RoomRating>();
            var rr = context.Hotels.Where(x => x.Id == hotelId)
                .Include(x => x.Rooms.Where(r => r.HotelId == hotelId));
            return result;
        }

        public virtual List<TopRoom> GetRoomRating(DateTime startTime, DateTime endTime, int hotelId)
        {
            var rooms = GetRoomsRating(hotelId);

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