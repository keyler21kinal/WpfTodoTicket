using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTodoTicket.Models;

namespace TodoTicketIn6av.Controllers
{
    public class CuentaController : Controller
    {
        public TodoTicket1Context1 db = new TodoTicket1Context1();

        int idUser;
        public ActionResult Login(Usuario usuario)
        {
            var usr = db.Usuario.FirstOrDefault(u => u.Correo == usuario.Correo && u.Contrasena == usuario.Contrasena);
            if (usr != null)
            {
                Session["idUsuario"] = usr.UsuarioId;
                idUser = usr.RolId;
                Session["nombreUsuario"] = usr.Nombre;
                return VerificarSesion();
            }
            else
            {
                ModelState.AddModelError("", "");

            }
            return View();
        }
        public ActionResult VerificarSesion()
        {
            if (idUser == 1)
            {
                return RedirectToAction("../Administrador/Index");
            }
            else if (idUser == 2)
            {
                return RedirectToAction("../Evento/Index");
            }
            return RedirectToAction("../Home/Index");
        }
        // GET: Cuenta
        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var rol = db.Rol.FirstOrDefault(r => r.RolId == 2);
                usuario.Rol = rol;
                db.Usuario.Add(usuario);
                db.SaveChanges();
                ViewBag.mensaje = "El usuario " + usuario.Nombre + " ha sido registrado correctamente.";
            }
            return RedirectToAction("Login", "Cuenta");
        }

        public ActionResult EditarCuenta()
        {
            int id = Convert.ToInt32(Session["idUsuario"]);
            Usuario usuario = db.Usuario.Find(id);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCuenta([Bind(Include = "UsuarioId,Nombre,Correo,Contrasena,RolId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var rol = db.Rol.FirstOrDefault(r => r.RolId == 2);
                db.Entry(usuario).State = EntityState.Modified;
                usuario.Rol = rol;
                db.SaveChanges();
                return RedirectToAction("Index", "Evento");
            }
            return View(usuario);
        }

        public ActionResult BorrarCuenta()
        {
            int id = Convert.ToInt32(Session["idUsuario"]);
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Registro", "Cuenta");
        }
    }
}