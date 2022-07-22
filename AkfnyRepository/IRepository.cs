using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TEntity, TId>
            where TEntity : class, IEntity<TId>
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> GetAllasync();
        TEntity Get(TId id);
        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate);
        Task<TId> Add(TEntity entity);
        Task AddRange(List<TEntity> entityList);
        void Update(TEntity entity);
        Task<int> SaveChangesAsync();
        int SaveChanges();
        void Delete(TEntity entity);
    }
}
