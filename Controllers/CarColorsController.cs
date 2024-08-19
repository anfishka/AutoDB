using AutoDB.Data;
using AutoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarColorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarColorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarColor>>> GetCarColors()
        {
            return await _context.Colors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarColor>> GetCarColor(int id)
        {
            var carColor = await _context.Colors.FindAsync(id);

            if (carColor == null)
            {
                return NotFound();
            }

            return carColor;
        }

        [HttpPost]
        public async Task<ActionResult<CarColor>> PostCarColor(CarColor carColor)
        {
            _context.Colors.Add(carColor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarColor), new { id = carColor.Id }, carColor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarColor(int id, CarColor carColor)
        {
            if (id != carColor.Id)
            {
                return BadRequest();
            }

            _context.Entry(carColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarColorExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarColor(int id)
        {
            var carColor = await _context.Colors.FindAsync(id);
            if (carColor == null)
            {
                return NotFound();
            }

            _context.Colors.Remove(carColor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarColorExists(int id)
        {
            return _context.Colors.Any(e => e.Id == id);
        }
    }
}