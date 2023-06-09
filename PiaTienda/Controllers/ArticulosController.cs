﻿using PiaTienda.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PiaTienda.Controllers
{
    [ApiController]
    [Route("api/Articulos")]
    public class ArticulosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("/ListadoTodosArticulos")]
        public async Task<ActionResult<List<Articulos>>> GetAll()
        {
            return await _context.Articulos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Articulos>> GetById(int id)
        {
            return await _context.Articulos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Articulos articulos)
        {
            var existeArticulo = await _context.Articulos.AnyAsync(x => x.NombreArticulo == articulos.NombreArticulo);
            if (existeArticulo)
            {
                return BadRequest("El articulo ya existe");
            }

            var existe = await _context.Articulos.AnyAsync(x => x.Id == articulos.CategoriasId);
            if (existe)
            {
                return BadRequest("La categoria no existe");
            }

            _context.Add(articulos);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Articulos articulos)
        {
            var existe = await _context.Articulos.AnyAsync(x => x.Id == articulos.CategoriasId);

            if (!existe)
            {
                return BadRequest("La categoria no existe");
            }

            if (id != articulos.Id)
            {
                return BadRequest("El id no coincide con lo establecido en la URL");
            }

            _context.Update(articulos);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Articulos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound("No se encontro en la base de datos");
            }

            _context.Remove(new Articulos() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
