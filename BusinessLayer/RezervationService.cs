using BusinessLayer.Interfaces;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class RezervationService : IRezervationService
    {
        public virtual ClientDbContext context { get; private set; }

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

        public virtual IEnumerable<Rezervation> GetAll()
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
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public virtual List<RezervedDays> GetRezervedDays(DateTime start, DateTime end, int roomId)
        {
            var result = new List<RezervedDays>();

            var days = context.Rezervations
                    .Where(x => x.RoomId == roomId && x.Checkin >= start).Where(x => x.Checkout <= end)
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

        public virtual List<BookedDays> GetBookedDays(DateTime start, DateTime end, int roomId)
        {
            var result = new List<BookedDays>();

            var rezervedDays = GetRezervedDays(start, end, roomId).OrderBy(x => x.StartDate).OrderBy(x=>x.StartDate);

            foreach (var rd in rezervedDays)
            {
                result.Add(
                    new BookedDays()
                    {
                        StartDate =start,
                        EndDate = rd.StartDate.AddDays(-1),
                        Status = PeriodWithStatus.FreePeriod
                    });
                result.Add(
                    new BookedDays()
                    {
                        StartDate = rd.StartDate,
                        EndDate = rd.EndDate,
                        Status = PeriodWithStatus.ReservedPeriod
                    });
                start = rd.EndDate.AddDays(1);
            }
            result.Add(
                    new BookedDays()
                    {
                        StartDate = start,
                        EndDate = end,
                        Status = PeriodWithStatus.FreePeriod
                    });
            return result;
        }
    }
}