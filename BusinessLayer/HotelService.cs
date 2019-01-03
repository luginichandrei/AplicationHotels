using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class HotelService
    {
        public Hotel Create(Hotel entity)
        {
            using (var context = new ClientDbContext())
            {
                context.Set<Hotel>().Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public Hotel Update(Hotel entity)
        {
            using (var context = new ClientDbContext())
            {
                context.Set<Hotel>().Attach(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public Hotel Delete(Hotel entity)
        {
            using (var context = new ClientDbContext())
            {
                context.Set<Hotel>().Attach(entity);
                context.Set<Hotel>().Remove(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public Hotel GetById(int id)
        {
            using (var context = new ClientDbContext())
            {
                return context.Set<Hotel>().Find(id);
            }
        }

        public IQueryable<Hotel> GetAll()
        {
            using (var context = new ClientDbContext())
            {
                return context.Hotels;
            }
        }
    }
}
