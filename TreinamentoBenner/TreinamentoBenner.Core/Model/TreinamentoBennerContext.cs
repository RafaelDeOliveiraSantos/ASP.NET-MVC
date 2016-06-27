using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoBenner.Core.Model
{
    public class TreinamentoBennerContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        
    }
}
