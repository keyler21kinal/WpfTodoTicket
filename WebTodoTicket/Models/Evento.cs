using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTodoTicket.Models
{
    public class Evento
    {
        public int EventoId { get; set; }

        [Required, StringLength(30)]
        public string Nombre { get; set; }

        [Required, StringLength(50)]
        public string Descripcion { get; set; }

        [Required, StringLength(1000)]
        public string Portada { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required, StringLength(40)]
        public string Lugar { get; set; }

        public int TipoEventoId { get; set; }
        public TipoEvento TipoEvento { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}