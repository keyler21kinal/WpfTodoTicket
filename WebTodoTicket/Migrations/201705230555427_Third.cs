namespace WebTodoTicket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Factura", "TicketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Factura", "TicketId");
            AddForeignKey("dbo.Factura", "TicketId", "dbo.Ticket", "TicketId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factura", "TicketId", "dbo.Ticket");
            DropIndex("dbo.Factura", new[] { "TicketId" });
            DropColumn("dbo.Factura", "TicketId");
        }
    }
}
