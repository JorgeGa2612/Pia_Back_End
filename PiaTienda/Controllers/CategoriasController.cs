using Microsoft.EntityFrameworkCore;
using PiaTienda.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace PiaTienda.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categorias>> GetById(int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpGet("/Lista Categorias")]
        public async Task<ActionResult<List<Categorias>>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Categorias categorias)
        {
            _context.Add(categorias);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Categorias categorias)
        {
            if (id != categorias.Id)
            {
                return BadRequest("El id no coincide con lo establecido en la URL");
            }

            _context.Update(categorias);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
           var existe = await _context.Categorias.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound("No se encontro en la base de datos");
            }

            _context.Remove(new Categorias() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
