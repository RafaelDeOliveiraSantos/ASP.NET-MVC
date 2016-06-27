using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBenner.Core.Repository.Common
{
    public class RepositoryBase<TEntity>: IRepository<TEntity> where TEntity : class
    {
        private TreinamentoBennerContext _context;
        private IDbSet<TEntity> _dbSet;
        private DbContextTransaction _dbContextTransaction;

        protected RepositoryBase()
        {
            _context = ServiceLocator.Current.GetInstance<TreinamentoBennerContext>();
            _dbSet = _context.Set<TEntity>();
        }

        protected TreinamentoBennerContext Context => _context;
        protected IDbSet<TEntity> DbSet => _dbSet;

        public void Save(TEntity t)
        {
            DbSet.AddOrUpdate(t);
        }

        public void Add(TEntity t)
        {
            DbSet.Add(t);
        }

        public void Update(TEntity t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
        }

        public void Delete(TEntity t)
        {
            DbSet.Remove(t);
        }

        public void Delete(int id)
        {
            DbSet.Remove(Find(id));
        }

        public TEntity Find(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntity> All(bool @readonly = false)
        {
            return @readonly ? DbSet.AsNoTracking() : DbSet;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return @readonly ? DbSet.Where(predicate).AsNoTracking() : DbSet.Where(predicate);
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
            _dbContextTransaction.Commit();
        }

        public void Rollback()
        {
            _dbContextTransaction.Rollback();
        }
    }
}
