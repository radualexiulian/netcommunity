using Microsoft.EntityFrameworkCore;
using Notifications.Data.Abstractions;
using Notifications.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private DbSet<TEntity> _dbSet;

        public Repository(NotificationDbContext notificationDbContext)
        {
            this._dbSet = notificationDbContext.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            this._dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            this._dbSet.Remove(this.GetById(id));
        }

        public TEntity GetById(int id)
        {
            return this._dbSet.FirstOrDefault(x => x.Id == id);
        }

        public TEntity Insert(TEntity entity)
        {
            return this._dbSet.Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return this._dbSet.Update(entity).Entity;
        }
    }
}
