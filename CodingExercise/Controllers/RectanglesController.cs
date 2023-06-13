using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodingExercise.Models;

namespace CodingExercise.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RectanglesController : ControllerBase
    {
        private readonly CodingExerciseContext _context;

        public RectanglesController(CodingExerciseContext context)
        {
            _context = context;
        }


        // GET: api/Rectangles
        [HttpGet]
        [ActionName("GetRectangles")]
        public async Task<ActionResult<List<Rectangle>>> GetRectangles()
        {
            if (_context.Rectangles == null)
            {
                return NotFound();

            }
            return Ok(await _context.Rectangles.ToListAsync());
        }

        // GET: api/Rectangles/5
        [HttpGet("{id}")]
        public ActionResult<Rectangle> GetRectangle(int id)
        {
            if (_context.Rectangles == null)
            {
                return NotFound();
            }
            var rectangle = _context.Rectangles.Find(id);

            if (rectangle == null)
            {
                return NotFound();
            }

            return rectangle;
        }


        // POST: api/Rectangles/GetMatchedRectangles
        [HttpPost]
        [ActionName("GetMatchedRectangles")]
        public async Task<ActionResult<List<Rectangle>>> GetMatchedRectangles(Rectangle request)
        {
            if (_context.Rectangles == null)
            {
                return NotFound();

            }

            RectangleResponse rectangleResponse = new RectangleResponse();

            rectangleResponse.LengthMatchedRectangles = await _context.Rectangles.Where(x => x.Length == request.Length).ToListAsync();
            rectangleResponse.WidthMatchedRectangles = await _context.Rectangles.Where(x => x.Width == request.Width).ToListAsync();
            rectangleResponse.HeightMatchedRectangles = await _context.Rectangles.Where(x => x.Height == request.Height).ToListAsync();
            rectangleResponse.VolumneMatchedRectangles = await _context.Rectangles.Where(x => x.Volume == request.Volume).ToListAsync();
            return Ok(rectangleResponse);
        }

        // DELETE: api/Rectangles/5
        /// <summary>
        /// Delete rectangle by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRectangle(int id)
        {
            if (_context.Rectangles == null)
            {
                return NotFound();
            }
            var rectangle = await _context.Rectangles.FindAsync(id);
            if (rectangle == null)
            {
                return NotFound();
            }

            _context.Rectangles.Remove(rectangle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //// POST: api/Rectangles
        /// <summary>
        /// Insert Rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        [HttpPost]
        public async Task<IActionResult> InsertRectangle(RectangleRequest rectangleRequest)
        {
            if (ModelState.IsValid)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = rectangleRequest.Width;
                rectangle.Height = rectangleRequest.Height;
                rectangle.Length = rectangleRequest.Length;
                try
                {
                    rectangle.Volume = rectangle.Width * rectangle.Length * rectangle.Height;
                }
                catch (ArithmeticException ex)
                {
                    throw ex;
                }
                _context.Rectangles.Add(rectangle);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //// POST: api/Rectangles
        /// <summary>
        /// Inser Rectangles
        /// </summary>
        /// <param name="rectangleRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert200Rectangles()
        {
            List<Rectangle> lstRectangles = new List<Rectangle>();
           for(int i = 1; i < 201; i++) 
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = i * 1;
                rectangle.Height = i * 1;
                rectangle.Length = i * 1;
                try
                {
                    rectangle.Volume = rectangle.Width * rectangle.Length * rectangle.Height;
                }
                catch (ArithmeticException ex)
                {
                    throw ex;
                }
                lstRectangles.Add(rectangle);
            }
          await _context.Rectangles.AddRangeAsync(lstRectangles);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
