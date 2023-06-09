﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiaTienda.Entidades;

namespace PiaTienda.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Clientes>> GetById(int id)
        {
            return await _context.Clientes.Include(x => x.Ventas).FirstOrDefaultAsync(x => x.Id == id);
        }


        [HttpPost]
        public async Task<ActionResult> Post(Clientes clientes)
        {
            _context.Add(clientes);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet ("/Lista")]
        public async Task<ActionResult<List<Clientes>>> GetAll()
        {
            return await _context.Clientes.Include(x => x.Ventas).ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Clientes clientes)
        {
            if (id != clientes.Id)
            {
                return BadRequest("El id no coincide con lo establecido en la URL");
            }

            _context.Update(clientes);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Clientes.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound("No se encontro en la base de datos");
            }

            _context.Remove(new Clientes() { Id = id});
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

