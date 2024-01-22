using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesAPI.Models;
using Newtonsoft.Json;

namespace EmployeesAPI.Controllers
{
    [Route("api/empleado")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeesAPIContext _context;

        public EmployeeController(EmployeesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Empleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetFactura([FromQuery]Employee empleado)
        {
            var query = _context.Employees.Where(f => f.id.Equals(empleado.id != 0 ? empleado.id : f.id));
            if (empleado.nit != null)
                query = query.Where(f => f.nit.Contains(empleado.nit));
            if (empleado.nombre != null)
                query = query.Where(f => f.nombre.Contains(empleado.nombre));
            if (empleado.fecha != null)
                query = query.Where(f => f.fecha.Contains(empleado.fecha));
            if (empleado.estado != 0)
                query = query.Where(f => f.id.Equals(empleado.estado));

            return await query
                .Include(d=>d.detalle)
                .ToListAsync();
        }

        // GET: api/Empleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetFactura(int id)
        {
            var factura = await _context.Employees.FindAsync(id);
                factura.detalle = await _context.FacturaDetalle.Where(d=>d.facturaId == id).ToListAsync();
            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }

        // PUT: api/Factura/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, Employee factura)
        {
            if (id != factura.id)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                ICollection<FacturaDetalle> faturaDetalle = factura.detalle;
                var deleteDetalle = new List<int>(); 
                int index = 0;
                foreach(FacturaDetalle detalle in faturaDetalle)
                {
                    if(detalle.id != 0)
                    {
                        if(detalle.facturaId == 0)
                        {
                            detalle.facturaId = factura.id;
                            deleteDetalle.Add(index);
                        }
                        else
                        {
                            _context.Entry(detalle).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        detalle.facturaId = factura.id;
                        _context.FacturaDetalle.Add(detalle);
                        await _context.SaveChangesAsync();
                    }
                    index++;
                }
                foreach(int detalleId in deleteDetalle)
                {
                    var detalle = faturaDetalle.ElementAt(detalleId);
                    if(detalle != null)
                    {
                        _context.FacturaDetalle.Remove(detalle);
                        await _context.SaveChangesAsync();
                        factura.detalle.Remove(detalle);
                    }
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return CreatedAtAction("GetFactura", new {}, factura);
        }

        // POST: api/Factura
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostFactura(Employee factura)
        {
            _context.Employees.Add(factura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactura", new { id = factura.id }, factura);
        }

        // DELETE: api/Factura/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            var factura = await _context.Employees.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaExists(int id)
        {
            return _context.Employees.Any(e => e.id == id);
        }
    }
}
