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
    public class AuthUserController : ControllerBase
    {
        private readonly AuthContext _context;
        private readonly IMapper _mapper; 
        public AuthUserController(AuthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AuthUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.AuthUser>>> Get([FromQuery]Model.SearchRequest.AuthUserSearchRequest search)
        {
            var authUsers =  _context.AuthUser
                            .Include(u => u.Role)                     
                            .ToList();
            #region search
            if (search != null)
            {
                if (search.qrCode != null)
                    authUsers = authUsers.Where(au => au.QrCode == search.qrCode).ToList();
                if (search.FirstName != null)
                    authUsers = authUsers.Where(au => au.FirstName.ToLower().StartsWith(search.FirstName.ToLower())).ToList();
                if (search.LastName != null)
                    authUsers = authUsers.Where(au => au.LastName.ToLower().StartsWith(search.LastName.ToLower())).ToList();
                if (search.UserName != null)
                    authUsers = authUsers.Where(au => au.UserName.ToLower().StartsWith(search.UserName.ToLower())).ToList();
                if (search.RoleId != null)
                    if(search.RoleId != 0)
                    authUsers = authUsers.Where(au => au.RoleId == search.RoleId).ToList();
                //search throught groups...
            }
            #endregion search
            var result = _mapper.Map<List<Model.AuthUser>>(authUsers);
            return result;
        }

        // GET: api/AuthUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model.AuthUser>> GetById(int id)
        {
            var authUser = await _context.AuthUser.FindAsync(id);

            if (authUser == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<Model.AuthUser>(authUser);

            return result;
        }

        // PUT: api/AuthUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<Model.AuthUser>> Put(int id, Model.InsertRequests.AuthUserInsertRequest insert)
        {
            Models.AuthUser authUser = _mapper.Map<Models.AuthUser>(insert);
            authUser.Id = id;



            try
            {
                var input = _mapper.Map<AuthoAPI.Models.AuthUser>(authUser);
                _context.Entry(input).State = EntityState.Modified;
                var result = await _context.AuthUser.FindAsync(id);
                await _context.SaveChangesAsync();

                return _mapper.Map<Model.AuthUser>(result);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool AuthUserExists(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/AuthUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Model.AuthUser>> PostAuthUser(Model.AuthUser insert)
        {
            Models.AuthUser input = _mapper.Map<Models.AuthUser>(insert);

            _context.AuthUser.Add(input);
            await _context.SaveChangesAsync();


            var result = await _context.AuthUser.FindAsync(input.Id);

            return _mapper.Map<Model.AuthUser>(result);

            //return CreatedAtAction("Get", new { id = authUser.Id }, authUser);
        }

        //// DELETE: api/AuthUsers/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<AuthUser>> DeleteAuthUser(int id)
        //{
        //    var authUser = await _context.AuthUser_1.FindAsync(id);
        //    if (authUser == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.AuthUser_1.Remove(authUser);
        //    await _context.SaveChangesAsync();

        //    return authUser;
        //}

        //private bool AuthUserExists(int id)
        //{
        //    return _context.AuthUser_1.Any(e => e.Id == id);
        //}
    }
}
