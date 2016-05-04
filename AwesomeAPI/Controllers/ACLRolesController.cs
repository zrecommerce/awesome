using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Authorization;
using AwesomeAPI.Models;

namespace AwesomeAPI.Controllers
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
                    return HttpNotFound();
                }
                return new ObjectResult(result);
            } catch (InvalidOperationException ) {
                return HttpNotFound();
            }
        }
        
        // POST api/aclroles
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Post([FromBody]ACLRole value)
        {
            if (value == null)
            {
                return HttpBadRequest();
            }
            _context.ACLRoles.Add(value);
            return CreatedAtRoute("Get", new { controller = "ACLRoles", id = value.ID }, value);
        }
        
        // PUT api/aclroles/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Put(int id, [FromBody]ACLPermission value)
        {
            // This method should be idempotent
            if (value == null || value.ID != id)
            {
                return HttpBadRequest();
            }
            
            if (ModelState.IsValid)
            {
                _context.Update(value);
                _context.SaveChanges();
                
                return new NoContentResult();
            } else {
                return HttpBadRequest();
            }
        }
        
        // DELETE api/aclroles/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryTokenAttribute]
        public void Delete(int id)
        {
            ACLRole resource = _context.ACLRoles.Single(m => m.ID == id);
            _context.ACLRoles.Remove(resource);
            _context.SaveChanges();
        }
    }
}