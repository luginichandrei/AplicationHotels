using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccessLayer
{
    public class ClientDbContext : DbContext
    {
        //private readonly string connectionString;

        //public ClientDbContext() : base()
        //{
        //}

        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options)
        {
        }

        //public ClientDbContext(string connectionString)
        //{
        //    this.connectionString = connectionString;
        //}

        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rezervation> Rezervations { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Use for  contextResolver
        //    //optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}