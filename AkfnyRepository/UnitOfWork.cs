using Akfny.Data;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Members
        readonly ApplicationDbContext _context;
        // readonly IIdentityProvider _identityProvider;
        #endregion

        #region Constructor
        public UnitOfWork(ApplicationDbContext context/*, IIdentityProvider identityProvider*/
            )
        {
            _context = context;
            // _identityProvider = identityProvider;
        }

        #endregion

        #region IUnitOfWork Members     

        public async Task<int> SaveChangesAsync()
        {
            SetIEntityFields();
            return await _context.SaveChangesAsync();
        }
        public int SaveChanges()
        {
            SetIEntityFields();
            return _context.SaveChanges();
        }

        public DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            var set = _context.Set<TEntity>();
            return set;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion

        #region Private Methods

        private void SetIEntityFields()
        {
            var now = DateTime.Now;
            // var userId = _identityProvider.GetUserId();

            _context.ChangeTracker.Entries<IEntity<int>>()
            .Where(e => e.State == EntityState.Added)
            .ToList()
            .ForEach(e =>
            {
                e.Entity.CreationDate = now;
              //  e.Entity.CreatedBy = userId;
            });
            _context.ChangeTracker.Entries<IEntity<int>>()
            .Where(e => e.State == EntityState.Added)
            .ToList()
            .ForEach(e =>
            {
                e.Entity.CreationDate = now;
                // e.Entity.CreatedBy = userId;
            });

            _context.ChangeTracker.Entries<IEntity<int>>()
            .Where(e => e.State == EntityState.Modified)
            .ToList()
            .ForEach(e =>
            {
                e.Entity.ModificationDate = now;
                //     e.Entity.ModifiedBy = userId;
            });

            _context.ChangeTracker.Entries<IEntity<Guid>>()
              .Where(e => e.State == EntityState.Modified)
              .ToList()
              .ForEach(e =>
              {
                  e.Entity.ModificationDate = now;
                  //     e.Entity.ModifiedBy = userId;
              });


        }

        #endregion
        public async Task<DbSet<TEntity>> CreateSetAsync<TEntity>() where TEntity : class
        {
            var set = _context.Set<TEntity>();
            return await Task.Run(() => set);
        }

    }
}
