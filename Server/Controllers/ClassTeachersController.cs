using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherTest.Server.Data;
using TeacherTest.Shared;

namespace TeacherTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassTeachersController : ControllerBase
    {
        private readonly AddDbContext _context;

        public ClassTeachersController(AddDbContext context)
        {
            _context = context;
        }

        // GET: api/ClassTeachers
        [HttpGet("getAllTeachersDetails")]
        public async Task<ActionResult<IEnumerable<ClassTeacher>>> GetClassTeachers()
        {
          if (_context.ClassTeachers == null)
          {
              return NotFound();
          }
            return await _context.ClassTeachers.ToListAsync();
        }

        // GET: api/ClassTeachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassTeacher>> GetClassTeacher(int id)
        {
          if (_context.ClassTeachers == null)
          {
              return NotFound();
          }
            var classTeacher = await _context.ClassTeachers.FindAsync(id);

            if (classTeacher == null)
            {
                return NotFound();
            }

            return classTeacher;
        }

        // PUT: api/ClassTeachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassTeacher(int id, ClassTeacher classTeacher)
        {
            if (id != classTeacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(classTeacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassTeacherExists(id))
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

        // POST: api/ClassTeachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("saveTeacherDetails")]
        public async Task<ActionResult<ClassTeacher>> PostClassTeacher(ClassTeacher classTeacher)
        {
          if (_context.ClassTeachers == null)
          {
              return Problem("Entity set 'AddDbContext.ClassTeachers'  is null.");
          }
            _context.ClassTeachers.Add(classTeacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassTeacher", new { id = classTeacher.Id }, classTeacher);
        }

        // DELETE: api/ClassTeachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassTeacher(int id)
        {
            if (_context.ClassTeachers == null)
            {
                return NotFound();
            }
            var classTeacher = await _context.ClassTeachers.FindAsync(id);
            if (classTeacher == null)
            {
                return NotFound();
            }

            _context.ClassTeachers.Remove(classTeacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassTeacherExists(int id)
        {
            return (_context.ClassTeachers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
