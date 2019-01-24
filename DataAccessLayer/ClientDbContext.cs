using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseDatatime && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseDatatime)entity.Entity).Created = DateTime.UtcNow;
                }
                ((BaseDatatime)entity.Entity).Modified = DateTime.UtcNow;
            }
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Use for  contextResolver
        //    //optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}