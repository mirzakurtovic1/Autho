using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthoAPI.Models;
using AutoMapper;

namespace AuthoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly AuthContext _context;
        private readonly IMapper _mapper;
        public UserGroupController(AuthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/UserGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.UserGroup>>> GetUserGroup()
        {
            var userGroups = await _context.UserGroup.ToListAsync();
            var result = _mapper.Map<List<Model.UserGroup>>(userGroups);
            return result;
        }

        //// GET: api/UserGroups/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserGroup>> GetUserGroup(int id)
        //{
        //    var userGroup = await _context.UserGroup.FindAsync(id);

        //    if (userGroup == null)
        //    {
        //        return NotFound();
        //    }

        //    return userGroup;
        //}

        //// PUT: api/UserGroups/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserGroup(int id, UserGroup userGroup)
        //{
        //    if (id != userGroup.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userGroup).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserGroupExists(id))
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

        //// POST: api/UserGroups
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<UserGroup>> PostUserGroup(UserGroup userGroup)
        //{
        //    _context.UserGroup.Add(userGroup);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUserGroup", new { id = userGroup.Id }, userGroup);
        //}

        //// DELETE: api/UserGroups/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<UserGroup>> DeleteUserGroup(int id)
        //{
        //    var userGroup = await _context.UserGroup.FindAsync(id);
        //    if (userGroup == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.UserGroup.Remove(userGroup);
        //    await _context.SaveChangesAsync();

        //    return userGroup;
        //}

        //private bool UserGroupExists(int id)
        //{
        //    return _context.UserGroup.Any(e => e.Id == id);
        //}
    }
}
