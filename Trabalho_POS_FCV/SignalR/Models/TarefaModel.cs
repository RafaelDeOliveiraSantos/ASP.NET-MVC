using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SignalR.Models
{
    public class TarefaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Tarefa")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public bool Done { get; set; }

        [DisplayName("Pessoa")]
        public int PessoaModelId { get; set; }

        public virtual PessoaModel Pessoa { get; set; }
    }
}