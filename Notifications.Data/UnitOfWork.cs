using Notifications.Data.Abstractions; 
using System.Threading.Tasks;

namespace Notifications.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NotificationDbContext _notificationDbContext;

        public UnitOfWork(NotificationDbContext notificationDbContext)
        {
            this._notificationDbContext = notificationDbContext;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await this._notificationDbContext.SaveChangesAsync() > 0;
        }

        IRepository<TEntity> IUnitOfWork.GetRepository<TEntity>()
        {
            return new Repository<TEntity>(this._notificationDbContext);
        }
    }
}
