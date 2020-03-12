using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthoAPI.Models;
using AutoMapper;
using Model.InsertRequests;

namespace AuthoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserFacesController : ControllerBase
    {
        private readonly AuthContext _context;
        private readonly IMapper _mapper;



        public AuthUserFacesController(AuthContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AuthUserFaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.AuthUserFace>>> GetAuthUserFace([FromQuery] Model.SearchRequest.AuthUserFaceSearchRequest search)
        {
            var result = await _context.AuthUserFace.ToListAsync();
            if (search != null)
            {
                if (search.AuthUserId > 0)
                {
                    result = result.Where(r => r.AuthUserId == search.AuthUserId).ToList();
                }
                if (search.onlyOne != null)
                {
                    if (search.onlyOne == true)
                    {
                        if (result.Count > 0)
                        {
                            List<AuthUserFace> l = new List<AuthUserFace>();
                            l.Add(result[0]);
                            return _mapper.Map<List<Model.AuthUserFace>>(l);
                        }
                    }
                }
            }
            return _mapper.Map<List<Model.AuthUserFace>>(result);
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
        public async Task<IActionResult> PutAuthUserFace(int id, Model.AuthUserFace insert)
        {
  
            var result = _mapper.Map<AuthUserFace>(insert);
            result.Id = id;
            _context.Entry(result).State = EntityState.Modified;


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
        public async Task<ActionResult<Model.AuthUserFace>> PostAuthUserFace(Model.AuthUserFace insert)
        {
            var result = _mapper.Map<AuthUserFace>(insert);
            try
            {
                _context.AuthUserFace.Add(result);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuthUserFaceExists(result.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAuthUserFace", new { id = result.Id }, result);
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
