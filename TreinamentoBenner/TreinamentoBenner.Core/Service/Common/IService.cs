using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoBenner.Core.Service.Common
{
    public interface IService<TEntity> where TEntity : class
    {
        void Save(TEntity t);
        void Add(TEntity t);
        void Update(TEntity t);
        void Delete(TEntity t);
        void Delete(int id);
        TEntity Find(int id);
        IQueryable<TEntity> All(bool @readonly = false);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
    }
}
