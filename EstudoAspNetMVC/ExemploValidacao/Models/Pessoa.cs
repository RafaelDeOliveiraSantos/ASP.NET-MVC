using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExemploValidacao.Models
{
    public class Pessoa
    {
        //As annotations podem ser validadas tanto pelo lado do cliente (JQuery.Validate)
        //quanto no lado do servidor (ModelState.IsValid)

        [Required(ErrorMessage = "Nome deve ser preenchido.")]
        public string Nome { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "A observação deve ter entre 50 a 5 caracteres.")]
        [Required(ErrorMessage = "Preencha a observação.")]
        public string Observacao { get; set; }
        
        [Range(10, 50, ErrorMessage = "A idade da pessoa deve ser entre 18 e 50 anos.")]
        [Required(ErrorMessage = "Informe uma idade.")]
        public int Idade { get; set; }
        
        [RegularExpression(@"^([\w\-]+\.)*[\w\- ]+@([\w\- ]+\.)+([\w\-]{2,3})$", ErrorMessage = "O E-Mail informado não é válido.")]
        public string Email { get; set; }
        
        [RegularExpression(@"[a-zA-Z]{5,15}", ErrorMessage = "O login deve possui somente letras e deve conter de 5 a 15 caracteres.")]
        [Required(ErrorMessage = "O login deve ser preenchido.")]
        [Remote("LoginUnico","Pessoa", ErrorMessage = "Este nome de login já existe.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmarSenha { get; set; }
    }
}