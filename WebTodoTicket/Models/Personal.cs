using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTodoTicket.Models
{
    public class Personal
    {
        public int PersonalId { get; set; }

        [Required, StringLength(30)]
        public string NombrePersonal { get; set; }

        [Required, StringLength(30)]
        public string Tipo { get; set; }
        public int EventoId { get; set; }
        public Evento evento { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}