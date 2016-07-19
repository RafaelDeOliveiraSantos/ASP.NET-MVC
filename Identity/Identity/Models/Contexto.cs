using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AulaIdentity.Models
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("Contexto")
        {

        }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<PermissaoModel> Permissao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PermissaoModel>()
                .HasMany<UsuarioModel>(h => h.Usuarios)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("PermissaoModelId");
                    m.MapRightKey("UsuarioModelId");
                    m.ToTable("PermissoesUsuario");
                });
        }
    }
}