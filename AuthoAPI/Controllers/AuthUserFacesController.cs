using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthoAPI.Models;

namespace AuthoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserFacesController : ControllerBase
    {
        private readonly AuthContext _context;

        public AuthUserFacesController(AuthContext context)
        {
            _context = context;
        }

        // GET: api/AuthUserFaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthUserFace>>> GetAuthUserFace()
        {
            return await _context.AuthUserFace.ToListAsync();
        }

        // GET: api/AuthUserFaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthUserFace>> GetAuthUserFace(int id)
        {
            var authUserFace = await _context.AuthUserFace.FindAsync(id);

            if (authUserFace == null)
            {
                return NotFound();
            }

            return authUserFace;
        }

        // PUT: api/AuthUserFaces/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthUserFace(int id, AuthUserFace authUserFace)
        {
            if (id != authUserFace.Id)
            {
                return BadRequest();
            }

            _context.Entry(authUserFace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthUserFaceExists(id))
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

        // POST: api/AuthUserFaces
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AuthUserFace>> PostAuthUserFace(AuthUserFace authUserFace)
        {
            _context.AuthUserFace.Add(authUserFace);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuthUserFaceExists(authUserFace.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAuthUserFace", new { id = authUserFace.Id }, authUserFace);
        }

        // DELETE: api/AuthUserFaces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthUserFace>> DeleteAuthUserFace(int id)
        {
            var authUserFace = await _context.AuthUserFace.FindAsync(id);
            if (authUserFace == null)
            {
                return NotFound();
            }

            _context.AuthUserFace.Remove(authUserFace);
            await _context.SaveChangesAsync();

            return authUserFace;
        }

        private bool AuthUserFaceExists(int id)
        {
            return _context.AuthUserFace.Any(e => e.Id == id);
        }
    }
}
