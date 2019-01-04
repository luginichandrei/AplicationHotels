using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Rezervation Update(Rezervation entity)
        {
            var local = context.Set<Rezervation>()
                        .Local.FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            context.Entry(local).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public Rezervation Delete(Rezervation entity)
        {
            context.Set<Rezervation>().Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
            return entity;
        }

        public Rezervation GetById(int id)
        {
            return context.Set<Rezervation>().Find(id);
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


    }
}
