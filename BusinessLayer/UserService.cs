using BusinessLayer.Interfaces;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class UserService : IUserService
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

        public User Delete(int id)
        {
            var entity = new User() { Id = id };
            context.Users.Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
            return entity;
        }

        public virtual IEnumerable<User> GetAll()
        {
            return context.Users.AsNoTracking();
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public User Update(User entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
    }
}