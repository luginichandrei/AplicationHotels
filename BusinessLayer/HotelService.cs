using BusinessLayer.Interfaces;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class HotelService : IHotelService
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

        public Hotel Delete(int id)
        {
            var entity = new Hotel() { Id = id };
            context.Hotels.Attach(entity);
            context.Hotels.Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public Hotel FindByName(string name)
        {
            return context.Hotels.Where(x => x.Name == name).FirstOrDefault();
        }

        public virtual IEnumerable<Hotel> GetAll()
        {
            return context.Hotels.AsNoTracking();
        }

        public Hotel GetById(int id)
        {
            return context.Hotels.Find(id);
        }

        public Hotel Update(Hotel entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
    }
}