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
        private ClientDbContext hotelContext;
        private HotelService() { }

        public HotelService(ClientDbContext hotelContext)
        {
            this.hotelContext = hotelContext;
        }

        public virtual Hotel Create(Hotel entity)
        {
            hotelContext.Set<Hotel>().Add(entity);
            hotelContext.SaveChanges();
            return entity;
        }

        public Hotel Update(Hotel entity)
        {
            var local = hotelContext.Set<Hotel>()
                        .Local
                        .FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            hotelContext.Entry(local).State = EntityState.Detached;
            hotelContext.Entry(entity).State = EntityState.Modified;
            hotelContext.SaveChanges();
            return entity;
        }

        public Hotel Delete(Hotel entity)
        {
            hotelContext.Set<Hotel>().Attach(entity);
            hotelContext.Set<Hotel>().Remove(entity);
            hotelContext.SaveChanges();
            return entity;
        }

        public Hotel GetById(int id)
        {
            return hotelContext.Hotels.Find(id);
        }

        public virtual IQueryable<Hotel> GetAll()
        {
            return hotelContext.Hotels.AsNoTracking();
        }

        public Hotel FindByName (string name)
        {
            return hotelContext.Hotels.Where(x => x.Name == name).Single();
        }
    }
}
