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
    public class MenusController : ControllerBase
    {
        private readonly MenuContext _context;

        public MenusController(MenuContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            return await _context.Menus.ToListAsync();
        }

        // GET: api/Menus/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Menu>> GetMenu(int id)
        //{
        //    var menu = await _context.Menus.FindAsync(id);

        //    if (menu == null)
        //    {
        //        return NotFound();
        //    }

        //    return menu;
        //}

        // GET: api/Menus/email/{emailID}

        [HttpGet("email/{emailID}")]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenuByEmail(string emailID)
        {
            var menus = await _context.Menus
                                      .Where(m => m.EmailId == emailID) // Ensure proper filtering by email
                                      .ToListAsync();

            if (menus == null || !menus.Any())
            {
                return NotFound();
            }

            return Ok(menus);
        }
























        // PUT: api/Menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, Menu menu)
        {
            if (id != menu.Id)
            {
                return BadRequest();
            }

            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
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

        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenu", new { id = menu.Id }, menu);
        }

        // DELETE: api/Menus/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMenu(int id)
        //{
        //    var menu = await _context.Menus.FindAsync(id);
        //    if (menu == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Menus.Remove(menu);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}





        // DELETE: api/Menus/foodId
        [HttpDelete("{foodId}")]
        public async Task<IActionResult> DeleteMenu(int foodId)
        {
            // Find the menu item based on FoodId
            var menu = await _context.Menus.FirstOrDefaultAsync(m => m.FoodId == foodId);

            if (menu == null)
            {
                return NotFound(); // Return 404 if not found
            }

            _context.Menus.Remove(menu); // Remove the found menu item
            await _context.SaveChangesAsync(); // Save changes to the database

            return NoContent(); // Return 204 No Content
        }




        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }
    }
}
