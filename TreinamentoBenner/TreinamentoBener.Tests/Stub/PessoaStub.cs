using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoBener.Tests.Factory;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBener.Tests.Stub
{
    public static class PessoaStub
    {
        public static Pessoa Valido()
        {
            return PessoaFactory.Create(1, "Danilo", 1, "Maringá", "PR");
        }

        public static Pessoa Invalido()
        {
            return new Pessoa();
        }
    }
}
