using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTodoTicket.Models
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        [Required, StringLength(40)]
        public string Nombre { get; set; }
        [Required, StringLength(40)]
        public string Nit { get; set; }
        public int EventoId { get; set; }       
        public Evento Evento { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}