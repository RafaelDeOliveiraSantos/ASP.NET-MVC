namespace MinhaLocadora.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MinhaLocadora.Models.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MinhaLocadora.Models.Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Pessoas.AddOrUpdate(
              p => p.FullName,
              new PessoaModel { Nome = "Adriano", Cpf = "123.456.789-10" },
              new PessoaModel { Nome = "José", Cpf = "123.456.789-11" },
              new PessoaModel { Nome = "Mariana", Cpf = "123.456.789-12" },
              new PessoaModel { Nome = "Maria", Cpf = "123.456.789-13" }
            );
            //
        }
    }
}
