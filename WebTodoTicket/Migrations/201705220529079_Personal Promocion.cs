namespace WebTodoTicket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalPromocion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Promocion",
                c => new
                {
                    PromocionId = c.Int(nullable: false, identity: true),
                    Descripcion = c.String(nullable: false),
                    EventoId = c.Int(nullable: false),
                    UsuarioId = c.Int(nullable: false),
                })
                .PrimaryKey(p => p.PromocionId)
                .ForeignKey("dbo.Evento", p => p.EventoId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", p => p.UsuarioId, cascadeDelete: false)
                .Index(p => p.EventoId)
                .Index(p => p.UsuarioId);

            CreateTable(
                "dbo.Personal",
                c => new
                {
                    PersonalId = c.Int(nullable: false, identity: true),
                    NombrePersonal = c.String(nullable: false, maxLength: 30),
                    Tipo = c.String(nullable: false, maxLength: 30),
                    EventoId = c.Int(nullable: false),
                    UsuarioId = c.Int(nullable: false),
                })
                .PrimaryKey(p => p.PersonalId)
                .ForeignKey("dbo.Evento", p => p.EventoId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", p => p.UsuarioId, cascadeDelete: false)
                .Index(p => p.EventoId)
                .Index(p => p.UsuarioId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Promocion", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Personal", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Promocion", new[] { "UsuarioId" });
            DropIndex("dbo.Personal", new[] { "UsuarioId" });
            DropColumn("dbo.Promocion", "UsuarioId");
            DropColumn("dbo.Personal", "UsuarioId");
        }
    }
}
