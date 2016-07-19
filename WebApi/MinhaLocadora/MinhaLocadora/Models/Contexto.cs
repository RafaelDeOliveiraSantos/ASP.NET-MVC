using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MinhaLocadora.Models
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("MinhaString")
            {}
        
        public DbSet<PessoaModel> Pessoas { get; set; }

        public DbSet<CarrosModel> Carros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}