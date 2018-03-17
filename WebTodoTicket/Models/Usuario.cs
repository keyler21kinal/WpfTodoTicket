using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTodoTicket.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required, StringLength(40)]
        public string Nombre { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [Required, StringLength(40)]
        public string Contrasena { get; set; }

        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}