using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTodoTicket.Models
{
    public class TipoEvento
    {
        public int TipoEventoId { get; set; }

        [Required, StringLength(30)]
        public string Descripcion { get; set; }

        public TipoEvento()
        {
            this.TipoEventoId = 0;
            this.Descripcion = string.Empty;
        }

        public TipoEvento(int tipoEventoId, string descripcion)
        {
            this.TipoEventoId = tipoEventoId;
            this.Descripcion = descripcion;
        }
    }
}