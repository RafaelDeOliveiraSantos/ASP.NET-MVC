using System.Data.Entity;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBenner.Core.Context.Initializer
{
    public class LojaInitializer : DropCreateDatabaseAlways<LojaContext>
    {
        protected override void Seed(LojaContext context)
        {
            context.Artistas.Add(new Artista {Nome = "Al Di Meola"});
            context.Generos.Add(new Genero {Nome = "Jazz"});
            context.Albums.Add(new Album
            {
                Artista = new Artista {Nome = "Chuck Berry"},
                Genero = new Genero {Nome = "Rock and roll"},
                Valor = 9.99m,
                Titulo = "Rock, Rock, Rock",
                UrlArte = "http://google.com/image.png"
            });
            base.Seed(context);
        }
    }
}
