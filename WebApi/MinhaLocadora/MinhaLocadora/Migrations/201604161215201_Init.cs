namespace MinhaLocadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarrosModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Modelo = c.String(),
                        Marca = c.String(),
                        AnoFabricacao = c.Int(nullable: false),
                        PessoaModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PessoaModel", t => t.PessoaModelId, cascadeDelete: true)
                .Index(t => t.PessoaModelId);
            
            CreateTable(
                "dbo.PessoaModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarrosModel", "PessoaModelId", "dbo.PessoaModel");
            DropIndex("dbo.CarrosModel", new[] { "PessoaModelId" });
            DropTable("dbo.PessoaModel");
            DropTable("dbo.CarrosModel");
        }
    }
}
