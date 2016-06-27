using System.Collections.Generic;

namespace TreinamentoBenner.Core.Model
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
