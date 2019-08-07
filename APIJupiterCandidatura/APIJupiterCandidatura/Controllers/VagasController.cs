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
    public class VagasController : ControllerBase
    {
        private readonly DbCandidaturaContext _context;

        public VagasController(DbCandidaturaContext context)
        {
            _context = context;
        }

        // GET: api/Vagas
        [HttpGet]
        public IEnumerable<Vaga> GetVagas()
        {
            return _context.Vagas;
        }

        // GET: api/Vagas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVaga([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vaga = await _context.Vagas.FindAsync(id);

            if (vaga == null)
            {
                return NotFound();
            }

            return Ok(vaga);
        }

        // PUT: api/Vagas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaga([FromRoute] int id, [FromBody] Vaga vaga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vaga.ID)
            {
                return BadRequest();
            }

            _context.Entry(vaga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagaExists(id))
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

        // POST: api/Vagas
        [HttpPost]
        public async Task<IActionResult> PostVaga([FromBody] Vaga vaga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vagas.Add(vaga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaga", new { id = vaga.ID }, vaga);
        }

        // DELETE: api/Vagas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaga([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vaga = await _context.Vagas.FindAsync(id);
            if (vaga == null)
            {
                return NotFound();
            }

            _context.Vagas.Remove(vaga);
            await _context.SaveChangesAsync();

            return Ok(vaga);
        }

        private bool VagaExists(int id)
        {
            return _context.Vagas.Any(e => e.ID == id);
        }
    }
}