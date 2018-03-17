namespace WebTodoTicket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        EventoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Portada = c.String(nullable: false, maxLength: 1000),
                        Fecha = c.DateTime(nullable: false),
                        Lugar = c.String(nullable: false, maxLength: 40),
                        TipoEventoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventoId)
                .ForeignKey("dbo.TipoEvento", t => t.TipoEventoId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.TipoEventoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.TipoEvento",
                c => new
                    {
                        TipoEventoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.TipoEventoId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 40),
                        Correo = c.String(nullable: false),
                        Contrasena = c.String(nullable: false, maxLength: 40),
                        RolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Rol", t => t.RolId, cascadeDelete: false)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        RolId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.RolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "RolId", "dbo.Rol");
            DropForeignKey("dbo.Evento", "TipoEventoId", "dbo.TipoEvento");
            DropIndex("dbo.Usuario", new[] { "RolId" });
            DropIndex("dbo.Evento", new[] { "UsuarioId" });
            DropIndex("dbo.Evento", new[] { "TipoEventoId" });
            DropTable("dbo.Rol");
            DropTable("dbo.Usuario");
            DropTable("dbo.TipoEvento");
            DropTable("dbo.Evento");
        }
    }
}
