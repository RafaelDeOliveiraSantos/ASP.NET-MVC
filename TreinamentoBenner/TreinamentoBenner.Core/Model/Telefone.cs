using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoBenner.Core.Model
{
    public class Telefone
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int IdPessoa { get; set; }
        [ForeignKey("IdPessoa")]
        public virtual Pessoa Pessoa { get; set; }
    }
}
