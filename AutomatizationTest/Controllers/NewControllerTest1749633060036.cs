using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoHorasExtras.Models;
using ProyectoHorasExtras.Data;

namespace ProyectoHorasExtras.Controllers
{
    public class SolicitudHorasExtrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitudHorasExtrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult RegistrarSolicitud(SolicitudHorasExtras solicitud)
        {
            if (ModelState.IsValid)
            {
                solicitud.FechaSolicitada = DateTime.Now;
                solicitud.Estado = "Pendiente";
                _context.SolicitudesHorasExtras.Add(solicitud);
                _context.SaveChanges();
                return RedirectToAction("EstadoSolicitud", new { id = solicitud.Id });
            }
            return View(solicitud);
        }
    }
}