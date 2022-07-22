using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork
    {
        DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
        Task<DbSet<TEntity>> CreateSetAsync<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
