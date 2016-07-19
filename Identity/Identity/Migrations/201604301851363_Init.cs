namespace Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PermissaoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Permissao = c.String(),
                        UsuarioModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UsuarioModels", t => t.UsuarioModel_Id)
                .Index(t => t.UsuarioModel_Id);
            
            CreateTable(
                "dbo.UsuarioModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PermissoesUsuario",
                c => new
                    {
                        PermissaoModelId = c.Int(nullable: false),
                        UsuarioModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PermissaoModelId, t.UsuarioModelId })
                .ForeignKey("dbo.PermissaoModels", t => t.PermissaoModelId, cascadeDelete: true)
                .ForeignKey("dbo.UsuarioModels", t => t.UsuarioModelId, cascadeDelete: true)
                .Index(t => t.PermissaoModelId)
                .Index(t => t.UsuarioModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PermissoesUsuario", "UsuarioModelId", "dbo.UsuarioModels");
            DropForeignKey("dbo.PermissoesUsuario", "PermissaoModelId", "dbo.PermissaoModels");
            DropForeignKey("dbo.PermissaoModels", "UsuarioModel_Id", "dbo.UsuarioModels");
            DropIndex("dbo.PermissoesUsuario", new[] { "UsuarioModelId" });
            DropIndex("dbo.PermissoesUsuario", new[] { "PermissaoModelId" });
            DropIndex("dbo.PermissaoModels", new[] { "UsuarioModel_Id" });
            DropTable("dbo.PermissoesUsuario");
            DropTable("dbo.UsuarioModels");
            DropTable("dbo.PermissaoModels");
        }
    }
}
