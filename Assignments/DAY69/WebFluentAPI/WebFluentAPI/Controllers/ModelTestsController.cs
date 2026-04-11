using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFluentAPI.Data;
using WebFluentAPI.Models;

namespace WebFluentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelTestsController : ControllerBase
    {
        private readonly WebFluentAPIContext _context;

        public ModelTestsController(WebFluentAPIContext context)
        {
            _context = context;
        }

        // GET: api/ModelTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelTest>>> GetModelTest()
        {
            return await _context.ModelTest.ToListAsync();
        }

        // GET: api/ModelTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelTest>> GetModelTest(int id)
        {
            var modelTest = await _context.ModelTest.FindAsync(id);

            if (modelTest == null)
            {
                return NotFound();
            }

            return modelTest;
        }

        // PUT: api/ModelTests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelTest(int id, ModelTest modelTest)
        {
            if (id != modelTest.Id)
            {
                return BadRequest();
            }

            _context.Entry(modelTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelTestExists(id))
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

        // POST: api/ModelTests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModelTest>> PostModelTest(ModelTest modelTest)
        {
            _context.ModelTest.Add(modelTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelTest", new { id = modelTest.Id }, modelTest);
        }

        // DELETE: api/ModelTests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelTest(int id)
        {
            var modelTest = await _context.ModelTest.FindAsync(id);
            if (modelTest == null)
            {
                return NotFound();
            }

            _context.ModelTest.Remove(modelTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelTestExists(int id)
        {
            return _context.ModelTest.Any(e => e.Id == id);
        }
    }
}
