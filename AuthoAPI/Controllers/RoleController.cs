//Scaffold-DbContext "Server=.;Database=Auth;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -f

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
    public class RoleController : ControllerBase
    {
        private readonly AuthContext _context;
        private readonly IMapper _mapper;
        public RoleController(AuthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<List<Model.Role>>> Get()
        {
            var list = await _context.Role.ToListAsync();

            //
            //Search request here...
            //

            return _mapper.Map <List<Model.Role>>(list);
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Role>> GetById(int id)
        {
            var role = await _context.Role.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }


            return _mapper.Map<Model.Role>(role); 
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<Model.Role>> Update(int id, Model.Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }
            

            

            try
            {
                var input = _mapper.Map<AuthoAPI.Models.Role>(role);
                _context.Entry(input).State = EntityState.Modified;

                var result = await _context.Role.FindAsync(id);

                await _context.SaveChangesAsync();
                return _mapper.Map<Model.Role>(result);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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
        public async Task<ActionResult<Role>> Insert(Model.Role role)
        {
            var newRole = _mapper.Map<AuthoAPI.Models.Role>(role);

            _context.Role.Add(newRole);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoleExists(role.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = newRole.Id }, newRole);
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

        private bool RoleExists(int id)
        {
            return _context.Role.Any(e => e.Id == id);
        }
    }
}
