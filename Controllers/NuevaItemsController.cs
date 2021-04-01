using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuevaApi.Models;


namespace NuevaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NuevaItemsController : ControllerBase
    {
        private readonly NuevaContext _context;

        public NuevaItemsController(NuevaContext context)
        {
            _context = context;
        }

        // GET: api/NuevaItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NuevaItem>>> GetNuevaItems()
        {
            return await _context.NuevaItems.ToListAsync();
        }

        // GET: api/NuevaItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NuevaItem>> GetNuevaItem(long id)
        {
            var nuevaItem = await _context.NuevaItems.FindAsync(id);

            if (nuevaItem == null)
            {
                return NotFound();
            }

            return nuevaItem;
        }

        // PUT: api/NuevaItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNuevaItem(long id, NuevaItem nuevaItem)
        {
            if (id != nuevaItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(nuevaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NuevaItemExists(id))
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

        // POST: api/NuevaItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NuevaItem>> PostNuevaItem(NuevaItem nuevaItem)
        {    

            string[] casa = { "Gryffindor", "Hufflepuff","Ravenclaw", "Slytherin"};
            if (!casa.Contains(nuevaItem.casa))
            {
                ModelState.AddModelError(nameof(nuevaItem.casa), "Casa invalida");
            }
            if(ModelState.IsValid){
                _context.NuevaItems.Add(nuevaItem);
                await _context.SaveChangesAsync();

                // return CreatedAtAction("GetNuevaItem", new { id = nuevaItem.Id }, nuevaItem);
                return CreatedAtAction(nameof(GetNuevaItem), new { id = nuevaItem.Id }, nuevaItem);
            }
            return View();

        }

        private ActionResult<NuevaItem> View()
        {
            throw new NotImplementedException();
        }

        // DELETE: api/NuevaItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNuevaItem(long id)
        {
            var nuevaItem = await _context.NuevaItems.FindAsync(id);
            if (nuevaItem == null)
            {
                return NotFound();
            }

            _context.NuevaItems.Remove(nuevaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NuevaItemExists(long id)
        {
            return _context.NuevaItems.Any(e => e.Id == id);
        }
    }
}
