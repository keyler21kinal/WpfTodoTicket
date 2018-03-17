using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTodoTicket.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        [Required]
        public int Precio { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}