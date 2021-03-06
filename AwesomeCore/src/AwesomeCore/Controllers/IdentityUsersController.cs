using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using AwesomeCore.Models;

namespace AwesomeCore.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class IdentityUsersController : Controller
    {
        private AwesomeContext _context;
        
        public IdentityUsersController(AwesomeContext context)
        {
            _context = context;
        }
        
        // GET: api/identityusers
        [HttpGet]
        public IEnumerable<IdentityUser> Get()
        {
            return _context.IdentityUsers.ToList();
        }
        
        // GET api/identityusers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IdentityUser result;
            
            try {
                result = _context.IdentityUsers.Single(m => m.ID == id);
                
                if (result == null)
                {
                    return NotFound();
                }
                return new ObjectResult(result);
            } catch (InvalidOperationException ) {
                return NotFound();
            }
        }
        
        // POST api/identityusers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post([FromBody]IdentityUser value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            _context.IdentityUsers.Add(value);
            return CreatedAtRoute("Get", new { controller = "IdentityUsers", id = value.ID }, value);
        }
        
        // PUT api/identityusers/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Put(int id, [FromBody]ACLPermission value)
        {
            // This method should be idempotent
            if (value == null || value.ID != id)
            {
                return BadRequest();
            }
            
            if (ModelState.IsValid)
            {
                _context.Update(value);
                _context.SaveChanges();
                
                return new NoContentResult();
            } else {
                return BadRequest();
            }
        }
        
        // DELETE api/identityusers/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public void Delete(int id)
        {
            IdentityUser resource = _context.IdentityUsers.Single(m => m.ID == id);
            _context.IdentityUsers.Remove(resource);
            _context.SaveChanges();
        }
    }
}