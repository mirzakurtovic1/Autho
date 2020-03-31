using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthoAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.SearchRequest;

namespace AuthoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        
            private readonly AuthContext _context;
            private readonly IMapper _mapper;
            public EventController(AuthContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<List<Model.Event>>> Get([FromQuery] EventSearchRequest search)
        {

            var list = await _context.Event
                                    .Include(e => e.EventType)
                                    .ToListAsync();

            //Search request
            if (search != null)
            {
                if (search.EventDate != null)
                {
                    DateTime temp = (DateTime)search.EventDate;
                    search.EventDate = new DateTime(temp.Year, temp.Month, temp.Day, 0, 0, 0, 0);
                
                }
                if (search.EventGroupId != null)
                    list = list.Where(e => e.EventGroupId == search.EventGroupId).ToList();
                if (search.EventDate != null)
                    list = list.Where(e => e.EventDate == search.EventDate).ToList();

                //searching for specifi time
                if (search.EventStartingTime != null && search.EventEndingTime != null)
                {
                    //
                    var list1 = list.Where(e => e.EventStartingTime <= search.EventStartingTime && e.EventEndingTime <= search.EventEndingTime).ToList(); //  x event x
                    var list2 = list.Where(e => e.EventStartingTime >= search.EventStartingTime && e.EventEndingTime >= search.EventEndingTime).ToList();// event x event
                    var list3 = list.Where(e => e.EventStartingTime <= search.EventStartingTime && e.EventStartingTime <= search.EventEndingTime).ToList();// x event_start x
                    var list4 = list.Where(e => e.EventEndingTime >= search.EventStartingTime && e.EventEndingTime <= search.EventEndingTime).ToList();// x event_end x
                    var finalList = new List<Event>();
                    if (list1.Count > 0) finalList= finalList.Concat(list1).ToList();
                    if (list2.Count > 0) finalList = finalList.Concat(list2).ToList();
                    if (list3.Count > 0) finalList = finalList.Concat(list3).ToList();
                    if (list4.Count > 0) finalList = finalList.Concat(list4).ToList();
                    
                    finalList = finalList
                                .GroupBy(e => e.Id)
                                .Select(g => g.First())
                                .ToList();
                    return _mapper.Map<List<Model.Event>>(finalList);
                }

            }

            return _mapper.Map<List<Model.Event>>(list);
        }

            // GET: api/Roles/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Model.Event>> GetById(int id)
            {
                var userEvent = await _context.Event.FindAsync(id);
                if (userEvent == null)
                {
                    return NotFound();
                }
                return _mapper.Map<Model.Event>(userEvent);
            }

            // PUT: api/Roles/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            [HttpPut("{id}")]
            public async Task<ActionResult<Model.Event>> Update(int id, Model.Event userEvent)
            {

                   userEvent.Id = id;

                try
                {
                    var input = _mapper.Map<AuthoAPI.Models.Event>(userEvent);
                    _context.Entry(input).State = EntityState.Modified;

                    var result = await _context.Event.FindAsync(id);

                    await _context.SaveChangesAsync();
                    return _mapper.Map<Model.Event>(result);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // POST: api/Roles
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            [HttpPost]
            public async Task<ActionResult<Model.Event>> Insert(Model.Event userEvent)
            {
                var newEvent = _mapper.Map<AuthoAPI.Models.Event>(userEvent);

                _context.Event.Add(newEvent);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (EventExists(userEvent.Id))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

            //return CreatedAtAction("Get", new { id = newEvent.Id }, newEvent);
            return _mapper.Map<Model.Event>(newEvent);  
        }

            //// DELETE: api/Roles/5
            //[HttpDelete("{id}")]
            //public async Task<ActionResult<Role>> DeleteRole(int id)
            //{
            //    var role = await _context.Role.FindAsync(id);
            //    if (role == null)
            //    {
            //        return NotFound();
            //    }

            //    _context.Role.Remove(role);
            //    await _context.SaveChangesAsync();

            //    return role;
            //}

            private bool EventExists(int id)
            {
                return _context.Event.Any(e => e.Id == id);
            }
        }
    
}