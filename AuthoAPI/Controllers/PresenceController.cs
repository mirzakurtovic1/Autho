using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthoAPI.Models;
using AutoMapper;
using Model.SearchRequest;

namespace AuthoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresenceController : ControllerBase
    {
        private readonly AuthContext _context;
        private readonly IMapper _mapper;
        public PresenceController(AuthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Presence
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.Presence>>> GetPresence([FromQuery]PresenceSearchRequest search)
        {
            var presence = await _context.Presence.Include(u =>u.User).ToListAsync();


            if (search != null)
            {
                if (search.UserId != null)
                    presence = presence.Where(p => p.UserId == search.UserId).ToList();
                if(search.EventId != null)
                    presence = presence.Where(p => p.EventId == search.EventId).ToList();
                if(search.hasNotes != null)
                    presence = presence.Where(p => p.Notes != null).ToList();

            }

            var result = _mapper.Map<List<Model.Presence>>(presence);
            return result;
        }

        // GET: api/Presence/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Presence>> GetPresence(int id)
        {
            var presence = await _context.Presence.FindAsync(id);

            if (presence == null)
            {
                return NotFound();
            }

            return _mapper.Map<Model.Presence>(presence);
        }

        // PUT: api/Presence/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresence(int id, Model.InsertRequests.PresenceInsertRequest request)
        {

            var presence = _mapper.Map<AuthoAPI.Models.Presence>(request);
            presence.Id = id;

            _context.Entry(presence).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresenceExists(id))
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

        // POST: api/Presence
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Presence>> PostPresence(Model.InsertRequests.PresenceInsertRequest request)
        {
            var presence = _mapper.Map<Models.Presence>(request);
            _context.Presence.Add(presence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPresence", new { id = presence.Id }, presence);
        }

        // DELETE: api/Presence/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Model.Presence>> DeletePresence(int id)
        {
            var presence = await _context.Presence.FindAsync(id);
            if (presence == null)
            {
                return NotFound();
            }

            _context.Presence.Remove(presence);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Presence>(presence);
        }

        private bool PresenceExists(int id)
        {
            return _context.Presence.Any(e => e.Id == id);
        }
    }
}
