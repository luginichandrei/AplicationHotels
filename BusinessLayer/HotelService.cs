using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class HotelService
    {
        private ClientDbContext context;

        public HotelService(ClientDbContext context)
        {
            this.context = context;
        }

        public virtual Hotel Create(Hotel entity)
        {
            context.Hotels.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public Hotel Update(Hotel entity)
        {
            var local = context.Hotels
                        .Local
                        .FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            context.Entry(local).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public Hotel Delete(Hotel entity)
        {
            context.Hotels.Attach(entity);
            context.Hotels.Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public Hotel GetById(int id)
        {
            return context.Hotels.Find(id);
        }

        public virtual IQueryable<Hotel> GetAll()
        {
            return context.Hotels.AsNoTracking();
        }

        public Hotel FindByName (string name)
        {
            return context.Hotels.Where(x => x.Name == name).Single();
        }

    }
}
