using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TreinamentoBenner.Core.Attributes;
using TreinamentoBenner.Core.Resources;

namespace TreinamentoBenner.Core.Model
{
    public class Album : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Artist", ResourceType = typeof(AlbumResource))]
        public int ArtistaId { get; set; }

        [Display(Name = "Genre", ResourceType = typeof(AlbumResource))]
        [Required]
        public int GeneroId { get; set; }

        [Display(Name = "Title", ResourceType = typeof(AlbumResource))]
        [DataType(DataType.MultilineText)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 3)]
        [MaxWords(10, ErrorMessage = "Existem muitas palavras em {0}")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        public decimal Valor { get; set; }

        [Display(Name = "ArtUrl", ResourceType = typeof(AlbumResource))]
        [DataType(DataType.ImageUrl)]
        //[RegularExpression(@"^https?://.*\.(jpeg|jpg|png)$", ErrorMessage = "A URL informada não é válida")]
        public string UrlArte { get; set; }

        public virtual Genero Genero { get; set; }
        public virtual Artista Artista { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UrlArte != null && UrlArte.EndsWith(".gif"))
            {
                yield return new ValidationResult("Não é suportado tipo de imagem GIF", new[] { "UrlArte" });
            }
        } 
    }
}
