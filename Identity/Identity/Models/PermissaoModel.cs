using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AulaIdentity.Models
{
    public class PermissaoModel
    {
        [Key]
        public int Id { get; set; }

        public string Permissao { get; set; }

        public ICollection<UsuarioModel> Usuarios { get; set; }
    }
}