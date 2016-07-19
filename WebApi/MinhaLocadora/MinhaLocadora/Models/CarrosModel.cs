namespace MinhaLocadora.Models
{
    public class CarrosModel
    {
        public int Id { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }

        public int AnoFabricacao { get; set; }

        public int PessoaModelId { get; set; }

        public virtual PessoaModel Pessoa { get; set; }
    }
}