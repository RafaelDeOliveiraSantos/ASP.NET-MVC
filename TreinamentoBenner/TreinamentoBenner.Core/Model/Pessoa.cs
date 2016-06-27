using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoBenner.Core.Model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCidade { get; set; }

        [ForeignKey("IdCidade")]
        public virtual Cidade Cidade { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
