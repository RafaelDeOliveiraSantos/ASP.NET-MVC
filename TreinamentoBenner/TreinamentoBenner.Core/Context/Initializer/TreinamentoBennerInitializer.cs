using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBenner.Core.Context.Initializer
{
    public class TreinamentoBennerInitializer : DropCreateDatabaseAlways<TreinamentoBennerContext>
    {
        protected override void Seed(TreinamentoBennerContext context)
        {
            var angraDosReis = new Cidade { Nome = "Angra dos Reis", Uf = "RJ" };
            context.Cidades.Add(angraDosReis);

            var antaGorda = new Cidade { Nome = "Anta Gorda", Uf = "RS" };
            context.Cidades.Add(antaGorda);

            context.Pessoas.Add(new Pessoa { Nome = "Danilo", Cidade = angraDosReis });
            context.Pessoas.Add(new Pessoa { Nome = "Dilma", Cidade = antaGorda });

            context.Produtos.Add(new Produto
            {
                Nome = "Danilo",
                Valor = 100,
                Ativo = true

            });

            context.Produtos.Add(new Produto
            {
                Nome = "Aderbal",
                Valor = 50,
                Ativo = false

            });

            base.Seed(context);
        }
    }
}
