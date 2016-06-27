using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Repository.Common;
using TreinamentoBenner.Core.Repository.Interfaces;
using TreinamentoBenner.Core.Service.Common;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Core.Service
{
    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {
        public CidadeService(ICidadeRepository repository) : base(repository)
        {
        }

        public IEnumerable<string> ListarEstados()
        {
            return All(true).GroupBy(q => q.Uf).Select(q => q.Key);
        }

        public IQueryable<Cidade> ListarPorEstado(string uf)
        {
            return Query(q => q.Uf == uf, true);
        }
    }
}
