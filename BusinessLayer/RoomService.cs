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

        public virtual IEnumerable<RoomsWithRezervation> GetHotelRoomsWithRezervation(int hotelId)
        {
            var result = context.Rooms.Where(h=>h.HotelId==hotelId)
                .Include(x=>x.Hotel)
                .Include(x => x.Rezervation).DefaultIfEmpty()
                .AsNoTracking()
                .ToList();
            var rooms = new List<RoomsWithRezervation>();
            foreach(var r in result)
            {
                rooms.Add(new RoomsWithRezervation() {

                    HotelId = r.HotelId,
                    HotelName= r.Hotel.Name,
                    Number= r.Number,
                    Price = r.Price,
                    ComfortLevel = r.ComfortLevel,
                    Capability = r.Capability,
                    Checkin = r.Rezervation.Select(x=>x.Checkout).FirstOrDefault(),
                    Checkout= r.Rezervation.Select(x=>x.Checkout).FirstOrDefault()

                });                   
                
            }
            return rooms.OrderBy(r=>r.Number);
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