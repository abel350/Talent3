using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Talento.Data;
using Talento.Models;

namespace Talento.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Candidato
        public async Task<IActionResult> Index()
        {
            return View(await _context.CandidatoViewModel.ToListAsync());
        }

        // GET: Candidato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatoViewModel = await _context.CandidatoViewModel
                .FirstOrDefaultAsync(m => m.IdCandidato == id);
            if (candidatoViewModel == null)
            {
                return NotFound();
            }

            return View(candidatoViewModel);
        }

        // GET: Candidato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCandidato,Apaterno,Amaterno,Nombre,Edad,FechaDeNacimineto,Pais,Estado,Ciudad,CodigoPostal,Correo,Telefono,Celular,Escolaridad,UltimoPuesto,SueldoDeseado,Comentarios,AvisoPrivacidad,FechaRegistro")] CandidatoViewModel candidatoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidatoViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidatoViewModel);
        }

        // GET: Candidato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatoViewModel = await _context.CandidatoViewModel.FindAsync(id);
            if (candidatoViewModel == null)
            {
                return NotFound();
            }
            return View(candidatoViewModel);
        }

        // POST: Candidato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCandidato,Apaterno,Amaterno,Nombre,Edad,FechaDeNacimineto,Pais,Estado,Ciudad,CodigoPostal,Correo,Telefono,Celular,Escolaridad,UltimoPuesto,SueldoDeseado,Comentarios,AvisoPrivacidad,FechaRegistro")] CandidatoViewModel candidatoViewModel)
        {
            if (id != candidatoViewModel.IdCandidato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoViewModelExists(candidatoViewModel.IdCandidato))
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
            return View(candidatoViewModel);
        }

        // GET: Candidato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatoViewModel = await _context.CandidatoViewModel
                .FirstOrDefaultAsync(m => m.IdCandidato == id);
            if (candidatoViewModel == null)
            {
                return NotFound();
            }

            return View(candidatoViewModel);
        }

        // POST: Candidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatoViewModel = await _context.CandidatoViewModel.FindAsync(id);
            _context.CandidatoViewModel.Remove(candidatoViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoViewModelExists(int id)
        {
            return _context.CandidatoViewModel.Any(e => e.IdCandidato == id);
        }
    }
}
