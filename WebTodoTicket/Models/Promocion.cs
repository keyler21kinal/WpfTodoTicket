using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTodoTicket.Models
{
    public class Promocion
    {
        public int PromocionId { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public int EventoId { get; set; }
        public Evento evento { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}