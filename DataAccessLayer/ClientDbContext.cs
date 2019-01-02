using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DataAccessLayer
{
    public class ClientDbContext : DbContext
    {
        string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public ClientDbContext() : base() { }

        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Checkouts> Checkouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
