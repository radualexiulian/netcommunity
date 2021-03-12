using Notifications.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Data.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetById(int id); 
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
    }
}
