namespace SignalR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TarefaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        Done = c.Boolean(nullable: false),
                        PessoaModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PessoaModels", t => t.PessoaModelId, cascadeDelete: true)
                .Index(t => t.PessoaModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TarefaModels", "PessoaModelId", "dbo.PessoaModels");
            DropIndex("dbo.TarefaModels", new[] { "PessoaModelId" });
            DropTable("dbo.TarefaModels");
        }
    }
}
