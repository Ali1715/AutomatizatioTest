using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using SistemaCompensaciones.Data;
using SistemaCompensaciones.Models;

namespace SistemaCompensaciones.Controllers
{
    public class RegistroDeHorasExtrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroDeHorasExtrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroDeHorasExtras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistroDeHorasExtras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadoId, Fecha, HorasTrabajadas")] RegistroDeHorasExtras registroDeHorasExtras)
        {
            if (ModelState.IsValid)
            {
                registroDeHorasExtras.Status = "Pendiente";
                _context.Add(registroDeHorasExtras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroDeHorasExtras);
        }
    }
}