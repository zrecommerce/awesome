using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using AwesomeCore.Models;

namespace AwesomeCore.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ACLPermissionsController : Controller
    {
        private AwesomeContext _context;
        
        public ACLPermissionsController(AwesomeContext context)
        {
            _context = context;
        }
        
        // GET: api/aclpermissions
        [HttpGet]
        public IEnumerable<ACLPermission> Get()
        {
            return _context.ACLPermissions.ToList();
        }

        // GET api/aclpermissions/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {   
            
            ACLPermission result;
            
            try {
                result = _context.ACLPermissions.Single(m => m.ID == id);
                
                if (result == null)
                {
                    return NotFound();
                }
                return new ObjectResult(result);
            } catch (InvalidOperationException ) {
                
                return NotFound();
            }
        }

        // POST api/aclpermissions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post([FromBody]ACLPermission value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            _context.ACLPermissions.Add(value);
            return CreatedAtRoute("Get", new { controller = "ACLPermissions", id = value.ID }, value);
        }

        // PUT api/aclpermissions/5
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

        // DELETE api/aclpermissions/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public void Delete(int id)
        {
            ACLPermission permission = _context.ACLPermissions.Single(m => m.ID == id);
            _context.ACLPermissions.Remove(permission);
            _context.SaveChanges();
        }
        
    }
}