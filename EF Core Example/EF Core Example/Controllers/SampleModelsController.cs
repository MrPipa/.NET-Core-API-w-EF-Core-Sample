using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EF_Core_Example.Models;

namespace EF_Core_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleModelsController : ControllerBase
    {
        private readonly SampleContext _context;

        public SampleModelsController(SampleContext context)
        {
            _context = context;
        }

        // GET: api/SampleModels
        [HttpGet]
        public IEnumerable<SampleModel> GetSampleModels()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("I am trying");
            try
            {
                return _context.SampleModels;
            }
            catch
            {
                Console.WriteLine("I failed");
            }
            return null;
        }

        // GET: api/SampleModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSampleModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sampleModel = await _context.SampleModels.FindAsync(id);

            if (sampleModel == null)
            {
                return NotFound();
            }

            return Ok(sampleModel);
        }

        // PUT: api/SampleModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleModel([FromRoute] Guid id, [FromBody] SampleModel sampleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sampleModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleModelExists(id))
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

        // POST: api/SampleModels
        [HttpPost]
        public async Task<IActionResult> PostSampleModel([FromBody] SampleModel sampleModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.SampleModels.Add(sampleModel);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSampleModel", new { id = sampleModel.Id }, sampleModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/SampleModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSampleModel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sampleModel = await _context.SampleModels.FindAsync(id);
            if (sampleModel == null)
            {
                return NotFound();
            }

            _context.SampleModels.Remove(sampleModel);
            await _context.SaveChangesAsync();

            return Ok(sampleModel);
        }

        private bool SampleModelExists(Guid id)
        {
            return _context.SampleModels.Any(e => e.Id == id);
        }
    }
}