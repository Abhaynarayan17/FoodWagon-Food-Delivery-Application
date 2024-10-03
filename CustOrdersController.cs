using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodWagon.Models;

namespace FoodWagon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustOrdersController : ControllerBase
    {
        private readonly CustOrderContext _context;

        public CustOrdersController(CustOrderContext context)
        {
            _context = context;
        }

        // GET: api/CustOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustOrders>>> GetCustOrders()
        {
            return await _context.CustOrders.ToListAsync();
        }

        // GET: api/CustOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustOrders>> GetCustOrders(int id)
        {
            var custOrders = await _context.CustOrders.FindAsync(id);

            if (custOrders == null)
            {
                return NotFound();
            }

            return custOrders;
        }

        // PUT: api/CustOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustOrders(int id, CustOrders custOrders)
        {
            if (id != custOrders.Id)
            {
                return BadRequest();
            }

            _context.Entry(custOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustOrdersExists(id))
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

        // POST: api/CustOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustOrders>> PostCustOrders(CustOrders custOrders)
        {
            _context.CustOrders.Add(custOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustOrders", new { id = custOrders.Id }, custOrders);
        }

        // DELETE: api/CustOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustOrders(int id)
        {
            var custOrders = await _context.CustOrders.FindAsync(id);
            if (custOrders == null)
            {
                return NotFound();
            }

            _context.CustOrders.Remove(custOrders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustOrdersExists(int id)
        {
            return _context.CustOrders.Any(e => e.Id == id);
        }
    }
}
