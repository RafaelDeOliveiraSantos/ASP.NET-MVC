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
    public class InMemoryCidadeService : ICidadeService
    {
        private readonly List<Cidade> _db = new List<Cidade>();

        public void Save(Cidade t)
        {
            var cidade = _db.FirstOrDefault(q => q.Id == t.Id);
            if (cidade != null)
                _db.Remove(cidade);
            _db.Add(t);
        }

        public void Add(Cidade t)
        {
            _db.Add(t);
        }

        public void Update(Cidade t) { }

        public void Delete(Cidade t)
        {
            _db.Remove(t);
        }

        public void Delete(int id)
        {
            Delete(Find(id));
        }

        public Cidade Find(int id)
        {
            return _db.FirstOrDefault(q => q.Id == id);
        }

        public IQueryable<Cidade> All(bool @readonly = false)
        {
            return _db.AsQueryable();
        }

        public IQueryable<Cidade> Query(Expression<Func<Cidade, bool>> predicate, bool @readonly = false)
        {
            return _db.Where(predicate.Compile()).AsQueryable();
        }

        public IEnumerable<string> ListarEstados()
        {
            return _db.GroupBy(q => q.Uf).Select(q => q.Key);
        }

        public IQueryable<Cidade> ListarPorEstado(string uf)
        {
            return _db.Where(q => q.Uf == uf).AsQueryable();
        }
    }
}
