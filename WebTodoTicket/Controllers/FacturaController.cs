using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTodoTicket.Models;

namespace WebTodoTicket.Controllers
{
    public class FacturaController : Controller
    {
        private TodoTicket1Context1 db = new TodoTicket1Context1();

        // GET: Factura
        public ActionResult Index()
        {
            var factura = db.Factura.Include(f => f.Evento).Include(f => f.Ticket);
            return View(factura.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Evento, "EventoId", "Nombre");
            ViewBag.TicketId = new SelectList(db.Ticket, "TicketId", "Precio");
            return View();
        }


        //POST: Factura/Create
        //Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaId,Fecha,Nombre,Nit,EventoId,TicketId")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Factura.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.Evento, "EventoId", "Nombre", factura.EventoId);
            ViewBag.TicketId = new SelectList(db.Ticket, "TicketId", "Precio", factura.TicketId);
            return View(factura);
        }
        //}
        public ActionResult FacturaPdf([Bind(Include = "FacturaId,Fecha,Nombre,Nit,EventoId,TicketId")] Factura factura)
        {
            Response.Clear();
            try
            {
                //Creas el documento
                Document document = new Document();
                FileStream dile = new FileStream(Server.MapPath("~/App_Data/Factura.pdf"), FileMode.Create);
                PdfWriter.GetInstance(document, dile);
                document.Open();
                document.Add(new Paragraph(factura.FacturaId));
                document.Add(new Paragraph("Fecha:" + factura.Fecha.ToString()));
                document.Add(new Paragraph("Nombre Cliente:" + factura.Nombre));
                document.Add(new Paragraph("Nit Cliente:" + factura.Nit));
                document.Add(new Paragraph("Nombre Evento:" + db.Evento.First().Nombre));
                document.Add(new Paragraph("Total:" + db.Ticket.First().Precio));
                document.Close();
                dile.Close();
                dile = null;
                Response.AddHeader("Content-Disposition", "attachment; filename=Factura.pdf");
                Response.ContentType = "application/pdf";
                Response.WriteFile(Server.MapPath("~/App_Data/Factura.pdf"));
                Response.End();
                return View();
            }
            catch (DocumentException ex)
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
