using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTodoTicket.Models
{
    public class Rol
    {
        public int RolId { get; set; }

        [Required, StringLength(20)]
        public string Nombre { get; set; }
    }
}