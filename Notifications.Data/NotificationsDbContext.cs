using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Notifications.Domain;
using Notifications.Dto.Settings;

namespace Notifications.Data
{
    public class NotificationDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<User> Users { get; set; }

        public NotificationDbContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public NotificationDbContext(IOptions<DbSettings> connectionStringOptions)
        {
            this._connectionString = connectionStringOptions.Value.NotificationsDbConnString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<User>().Property(x => x.FirstName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<User>().Property(x => x.LastName).IsRequired().HasMaxLength(255);
        }
    }
}
