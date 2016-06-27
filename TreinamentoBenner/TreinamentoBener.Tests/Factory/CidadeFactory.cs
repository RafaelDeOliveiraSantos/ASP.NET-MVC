using TreinamentoBenner.Core.Model;

namespace TreinamentoBener.Tests.Factory
{
    public static class CidadeFactory
    {
        public static Cidade Create(int id, string nome, string uf)
        {
            return new Cidade { Id = id, Nome = nome, Uf = uf };
        }
    }
}
