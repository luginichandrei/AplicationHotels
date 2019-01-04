using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class RezervationService
    {
        private readonly ClientDbContext context;

        public RezervationService(ClientDbContext context)
        {
            this.context = context;
        }

        public Rezervation Create(Rezervation entity)
        {
            context.Rezervations.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public Rezervation Delete(int id)
        {
            var entity = new Rezervation() { Id = id };
            context.Set<Rezervation>().Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
            return entity;
        }

        public virtual IQueryable<Rezervation> GetAll()
        {
            return context.Rezervations.AsNoTracking();
        }

        public List<Rezervation> GetByHotelId(int hotelId)
        {
            var rooms = context.Rezervations
                .Include(x => x.Rooms)
                    .Where(x => x.Rooms.HotelId == hotelId && x.RoomId == x.Rooms.Id)
                 .AsNoTracking()
                 .ToList();
            return rooms;
        }

        public Rezervation GetById(int id)
        {
            return context.Set<Rezervation>().Find(id);
        }

        public Rezervation Update(Rezervation entity)
        {
            var local = context.Set<Rezervation>()
                        .Local.FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            context.Entry(local).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public List<RezervedDays> GetRezervedDays(DateTime start, DateTime end, int roomId)
        {
            var result = new List<RezervedDays>();

            var days = context.Rezervations
                    .Where(x => x.RoomId == roomId && x.Checkin <= start && x.Checkout >= end)
                 .AsNoTracking().ToList();

            foreach (var d in days)
            {
                result.Add(new RezervedDays()
                {
                    StartDate = d.Checkin,
                    EndDate = d.Checkout
                });
            }
            return result;
        }

        public List<BookedDays> GetBookedDay(DateTime start, DateTime end, int roomId)
        {
            var result = new List<BookedDays>();
            var rezervedDays = GetRezervedDays(start, end, roomId);
            var sd = start;
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
    }
}