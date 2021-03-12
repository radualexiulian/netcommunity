using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Notifications.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.ProcessorJob.DbContextFactory
{
    public class NotificationsDbContextFactory : IDesignTimeDbContextFactory<NotificationDbContext>
    { 
        public NotificationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetSection("ConnectionStrings:NotificationsDbConnString").Value;
             
            return new NotificationDbContext(connectionString);
        }
    }
}
