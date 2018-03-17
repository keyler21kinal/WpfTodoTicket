namespace WebTodoTicket.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class TodoTicket1Context1 : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'TodoTicket1Context' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'WebTodoTicket.Models.TodoTicket1Context' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'TodoTicket1Context'  en el archivo de configuración de la aplicación.
        public TodoTicket1Context1()
            : base("name=TodoTicket1Context1")
        {
        }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Promocion> Promocion { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Factura> Factura { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}