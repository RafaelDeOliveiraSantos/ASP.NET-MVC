using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TreinamentoBenner.Core.Repository.Common;

namespace TreinamentoBenner.Core.Service.Common
{
    public class ServiceBase<TEntity> : IService<TEntity> where TEntity : class 
    {
        IRepository<TEntity> _repository;

        public ServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Save(TEntity t)
        {
            _repository.BeginTransaction();
            _repository.Save(t);
            _repository.Commit();
        }

        public void Add(TEntity t)
        {
            _repository.BeginTransaction();
            _repository.Add(t);
            _repository.Commit();
        }

        public void Update(TEntity t)
        {
            _repository.BeginTransaction();
            _repository.Update(t);
            _repository.Commit();
        }

        public void Delete(TEntity t)
        {
            _repository.BeginTransaction();
            _repository.Delete(t);
            _repository.Commit();
        }

        public void Delete(int id)
        {
            _repository.BeginTransaction();
            _repository.Delete(id);
            _repository.Commit();
        }

        public TEntity Find(int id)
        {
            return _repository.Find(id);
        }

        public IQueryable<TEntity> All(bool @readonly = false)
        {
            return _repository.All(@readonly);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return _repository.Query(predicate, @readonly);
        }
    }
}
