using TreinamentoBenner.Core.Model;
using System.Data.Entity;

namespace TreinamentoBenner.Core.Context
{
    public class LojaContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}
