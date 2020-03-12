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
    public class AuthUserImagesController : ControllerBase
    {
        private readonly AuthContext _context;
        private readonly IMapper _mapper;
        public AuthUserImagesController(AuthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AuthUserImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.AuthUserImage>>> GetAuthUserImage([FromQuery] Model.SearchRequest.AuthUserFaceSearchRequest search)
        {
            var userImages = await _context.AuthUserImage.ToListAsync();
            if (search != null)
                if (search.AuthUserId != 0)
                    userImages = userImages.Where(u => u.AuthUserId == search.AuthUserId).ToList();



            return _mapper.Map<List<Model.AuthUserImage>>(userImages);
        }

        // GET: api/AuthUserImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthUserImage>> GetAuthUserImage(int id)
        {
            var authUserImage = await _context.AuthUserImage.FindAsync(id);

            if (authUserImage == null)
            {
                return NotFound();
            }

            return authUserImage;
        }

        // PUT: api/AuthUserImages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthUserImage(int id, Model.AuthUserImage insert)
        {
            
            try
            {
                var result = _mapper.Map<AuthUserImage>(insert);
                result.Id = id;
                _context.Entry(result).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthUserImageExists(id))
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

        // POST: api/AuthUserImages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Model.AuthUserImage>> PostAuthUserImage(Model.AuthUserImage insert)
        {

            var result = _mapper.Map<AuthUserImage>(insert);
            try
            {
                _context.AuthUserImage.Add(result);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuthUserImageExists(result.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAuthUserImage", new { id = result.Id }, result);
        }

        // DELETE: api/AuthUserImages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthUserImage>> DeleteAuthUserImage(int id)
        {
            var authUserImage = await _context.AuthUserImage.FindAsync(id);
            if (authUserImage == null)
            {
                return NotFound();
            }

            _context.AuthUserImage.Remove(authUserImage);
            await _context.SaveChangesAsync();

            return authUserImage;
        }

        private bool AuthUserImageExists(int id)
        {
            return _context.AuthUserImage.Any(e => e.Id == id);
        }
    }
}
