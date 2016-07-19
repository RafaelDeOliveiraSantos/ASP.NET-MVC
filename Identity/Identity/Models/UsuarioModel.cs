using AulaIdentity.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class UsuarioModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "* Obrigatorio")]
    public string UserName { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "* Obrigatorio")]
    public string Senha { get; set; }

    public ICollection<PermissaoModel> Permissoes { get; set; }
}

public class UsuarioRegistroModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "* Obrigatorio")]
    public string UserName { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "* Obrigatorio")]
    public string Senha { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "* Obrigatorio")]
    [Compare("Senha", ErrorMessage = "A Senha e a Confirmação da senha precisam ser iguais.")]
    [Display(Name = "Confirmação da Senha")]
    public string ConfirmacaoSenha { get; set; }
}

public class LoginModel
{
    [Required(ErrorMessage = "* Obrigatorio")]
    public string UserName { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "* Obrigatorio")]
    public string Senha { get; set; }
}