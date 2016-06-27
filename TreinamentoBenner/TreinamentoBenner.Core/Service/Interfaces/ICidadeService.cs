using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Common;

namespace TreinamentoBenner.Core.Service.Interfaces
{
    public interface ICidadeService : IService<Cidade>
    {
        IEnumerable<string> ListarEstados();

        IQueryable<Cidade> ListarPorEstado(string uf);
    }
}
