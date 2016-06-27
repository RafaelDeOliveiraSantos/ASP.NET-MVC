using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBener.Tests.Factory
{
    public static class PessoaFactory
    {
        public static Pessoa Create(int id, string nome, int cidadeId, string cidadeNome, string cidadeUf)
        {
            return new Pessoa
            {
                Id = id,
                Nome = nome,
                Cidade = CidadeFactory.Create(cidadeId, cidadeNome, cidadeUf)
            };
        }
    }
}
