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
        public ClientDbContext() : base() { }

        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Rezervation> Rezervations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        }
    }
}
