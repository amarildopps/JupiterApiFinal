using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIJupiterCandidatura.Model;

namespace APIJupiterCandidatura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatosController : ControllerBase
    {
        private readonly DbCandidaturaContext _context;

        public CandidatosController(DbCandidaturaContext context)
        {
            _context = context;
        }

        // GET: api/Candidatos
        [HttpGet]
        public IEnumerable<Candidato> GetCandidatos()
        {
            return _context.Candidatos;
        }

        // GET: api/Candidatos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidato([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidato = await _context.Candidatos.FindAsync(id);

            if (candidato == null)
            {
                return NotFound();
            }

            return Ok(candidato);
        }

        // PUT: api/Candidatos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidato([FromRoute] int id, [FromBody] Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidato.ID)
            {
                return BadRequest();
            }

            _context.Entry(candidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Candidatos
        [HttpPost]
        public async Task<IActionResult> PostCandidato([FromBody] Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Candidatos.Add(candidato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidato", new { id = candidato.ID }, candidato);
        }

        // DELETE: api/Candidatos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidato([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }

            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();

            return Ok(candidato);
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.ID == id);
        }
    }
}