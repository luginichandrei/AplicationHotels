using BusinessLayer.Interfaces;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class RoomService : IRoomService
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

        public Room Delete(int id)
        {
            var entity = new Room() { Id = id };
            context.Rooms.Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
            return entity;
        }

        public List<Room> FindByHotelId(int hotelId)
        {
            return context.Rooms.Where(x => x.HotelId == hotelId).ToList();
        }

        public Room FindByNumber(int number, int hotelId)
        {
            return context.Rooms.Where(x => x.Number == number && x.HotelId == hotelId).FirstOrDefault();
        }

        public virtual IEnumerable<Room> GetAll()
        {
            return context.Rooms.AsNoTracking();
        }

        public Room GetById(int id)
        {
            return context.Rooms.Find(id);
        }

        public virtual IEnumerable<RoomRating> GetHotelRooms(int hotelId)
        {
            var result = context.Hotels.Where(x => x.Id == hotelId)
                    .Join(context.Rooms, p => p.Id, pc => pc.HotelId, (p, pc) => new { p, pc })
                    .Join(context.Rezervations, ppc => ppc.pc.Id, c => c.RoomId, (ppc, c) => new RoomRating
                    {
                        HotelName = ppc.p.Name,
                        RoomNumber = ppc.pc.Number,
                        Days = c.Checkin
                    })
                    .ToList();
            return result;
        }

        public virtual List<TopRoom> GetRoomRating(DateTime startTime, DateTime endTime, int hotelId)
        {
            var rooms = GetHotelRooms(hotelId);

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

        public Room Update(Room entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
    }
}