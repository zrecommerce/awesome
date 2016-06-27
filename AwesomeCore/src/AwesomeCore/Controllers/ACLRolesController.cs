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
    public class ACLRolesController : Controller
    {
        private AwesomeContext _context;
        
        public ACLRolesController(AwesomeContext context)
        {
            _context = context;
        }
        
        // GET: api/aclroles
        [HttpGet]
        public IEnumerable<ACLRole> Get()
        {
            return _context.ACLRoles.ToList();
        }
        
        // GET api/aclroles/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ACLRole result;
            
            try {
                result = _context.ACLRoles.Single(m => m.ID == id);
                
                if (result == null)
                {
                    return NotFound();
                }
                return new ObjectResult(result);
            } catch (InvalidOperationException ) {
                return NotFound();
            }
        }
        
        // POST api/aclroles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post([FromBody]ACLRole value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            _context.ACLRoles.Add(value);
            return CreatedAtRoute("Get", new { controller = "ACLRoles", id = value.ID }, value);
        }
        
        // PUT api/aclroles/5
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
        
        // DELETE api/aclroles/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public void Delete(int id)
        {
            ACLRole resource = _context.ACLRoles.Single(m => m.ID == id);
            _context.ACLRoles.Remove(resource);
            _context.SaveChanges();
        }
    }
}