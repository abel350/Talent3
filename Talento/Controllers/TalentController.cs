using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talento.Data;
using Talento.Models;

namespace Talento.Controllers
{
    [Route("CoreUI")]
    public class TalentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TalentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("{view=Index}")]
        public IActionResult Index(string view)
        {
            ViewData["Title"] = "Páginas de Talent";
            return View(view);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Usuario,Membresia,Apaterno,Amaterno,Nombre,Empresa,GiroEmpresa,Puesto,Telefono,Correo,Ciudad,TipoMembresia,FechaIngreso")] Users users)
        {
            if (id != users.Id_Usuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id_Usuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }
        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id_Usuario == id);
        }

    }
}

