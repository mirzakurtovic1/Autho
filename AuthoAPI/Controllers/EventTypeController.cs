using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthoAPI.Models;
using Model;
using AutoMapper;

namespace AuthoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly AuthContext _context;
        private readonly IMapper _mapper;
        public EventTypeController(AuthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<List<Model.EventType>>> Get()
        {
            var list = await _context.EventType.ToListAsync();

            //
            //Search request here...
            //

            return _mapper.Map<List<Model.EventType>>(list);
        }

        //// GET: api/EventTypes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<EventType>> GetEventType(int id)
        //{
        //    var eventType = await _context.EventType_1.FindAsync(id);

        //    if (eventType == null)
        //    {
        //        return NotFound();
        //    }

        //    return eventType;
        //}

        //// PUT: api/EventTypes/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEventType(int id, EventType eventType)
        //{
        //    if (id != eventType.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(eventType).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EventTypeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/EventTypes
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<EventType>> PostEventType(EventType eventType)
        //{
        //    _context.EventType_1.Add(eventType);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEventType", new { id = eventType.Id }, eventType);
        //}

        //// DELETE: api/EventTypes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<EventType>> DeleteEventType(int id)
        //{
        //    var eventType = await _context.EventType_1.FindAsync(id);
        //    if (eventType == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.EventType_1.Remove(eventType);
        //    await _context.SaveChangesAsync();

        //    return eventType;
        //}

        //private bool EventTypeExists(int id)
        //{
        //    return _context.EventType_1.Any(e => e.Id == id);
        //}
    }
}
