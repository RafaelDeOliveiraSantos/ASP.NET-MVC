using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBener.Tests.Services
{
    public class InMemoryPessoaService : IPessoaService
    {
        private readonly List<Pessoa> _db = new List<Pessoa>();

        public void Save(Pessoa t)
        {
            var pessoa   = _db.FirstOrDefault(q => q.Id == t.Id);
            if (pessoa != null)
                _db.Remove(pessoa);
            _db.Add(t);
        }

        public void Add(Pessoa t)
        {
            _db.Add(t);
        }

        public void Update(Pessoa t)
        {
            
        }

        public void Delete(Pessoa t)
        {
            _db.Remove(t);
        }

        public void Delete(int id)
        {
            Delete(Find(id));
        }

        public Pessoa Find(int id)
        {
            return _db.FirstOrDefault(q => q.Id == id);
        }

        public IQueryable<Pessoa> All(bool @readonly = false)
        {
            return _db.AsQueryable();
        }

        public IQueryable<Pessoa> Query(Expression<Func<Pessoa, bool>> predicate, bool @readonly = false)
        {
            return _db.Where(predicate.Compile()).AsQueryable();
        }
    }
}
