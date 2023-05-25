using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiaTienda.Entidades;

namespace PiaTienda.Controllers

{
    [ApiController]
    [Route("api/empleados")]

    public class EmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Empleados>> GetById(int id)
        {
            return await _context.Empleados.FirstOrDefaultAsync(x => x.Id == id);
        }


        [HttpGet("/Lista Empleados")]
        public async Task<ActionResult<List<Empleados>>> GetAll()
        {
            return await _context.Empleados.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Empleados empleados)
        {
            _context.Add(empleados);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Empleados empleados)
        {
            if (id != empleados.Id)
            {
                return BadRequest("El id no coincide con lo establecido en la URL");
            }

            _context.Update(empleados);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
           var existe = await _context.Empleados.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound("No se encontro en la base de datos");
            }
            _context.Remove(new Empleados() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
