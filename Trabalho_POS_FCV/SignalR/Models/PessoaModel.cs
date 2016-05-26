using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SignalR.Models
{
    public class PessoaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Pessoa")]
        public string Nome { get; set; }

        [Required]
        public int Idade { get; set; }

        [Required]
        public string Nacionalidade { get; set; }

        [DisplayName("Estado Civil")]
        public string EstadoCivil { get; set; }

        public bool Inativo { get; set; }

        [JsonIgnore]
        public ICollection<TarefaModel> Tarefas { get; set; }
    }
}