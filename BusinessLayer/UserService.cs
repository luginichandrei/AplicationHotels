using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class UserService
    {
        private readonly ClientDbContext context;

        public UserService(ClientDbContext context)
        {
            this.context = context;
        }

        public User Create(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public User Update(User entity)
        {
            var local = context.Users
                        .Local.FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            context.Entry(local).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public User Delete(User entity)
        {
            context.Users.Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
            return entity;
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public virtual IQueryable<User> GetAll()
        {
            return context.Users.AsNoTracking();
        }




    }
}
