using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
           where TEntity : class, IEntity<TId>
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _unitOfWork.CreateSet<TEntity>();
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate != null)
            {
                return GetAll().Where(predicate);
            }
            else
            {
                throw new ArgumentNullException("The <predicate> paramter is required.");
            }
        }
        public async Task<IQueryable<TEntity>> GetAllasync()
        {
            return await _unitOfWork.CreateSetAsync<TEntity>();
        }
        public TEntity Get(TId id)
        {
            return GetAll().FirstOrDefault(c => c.Id.Equals(id));
        }
        public TEntity GetFirst(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate != null)
            {
                IQueryable<TEntity> query = GetAll().Where(predicate);
                return query.FirstOrDefault();
            }
            else
            {
                throw new ArgumentNullException("The <predicate> paramter is required.");
            }

        }

        public async Task<TId> Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var dbSet = _unitOfWork.CreateSet<TEntity>();
           await dbSet.AddAsync(entity);
            var result= SaveChanges();
            return entity.Id;
        }

        public async Task AddRange(List<TEntity> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var dbSet = _unitOfWork.CreateSet<TEntity>();
            await dbSet.AddRangeAsync(entity);
            var result = SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var dbSet = _unitOfWork.CreateSet<TEntity>();
            dbSet.Update(entity);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }public int SaveChanges()
        {
            return  _unitOfWork.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var dbSet = _unitOfWork.CreateSet<TEntity>();
            dbSet.Remove(entity);
        }
    }

}
