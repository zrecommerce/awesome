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
                    return HttpNotFound();
                }
                return new ObjectResult(result);
            } catch (InvalidOperationException ) {
                
                return HttpNotFound();
            }
        }

        // POST api/aclpermissions
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Post([FromBody]ACLPermission value)
        {
            if (value == null)
            {
                return HttpBadRequest();
            }
            _context.ACLPermissions.Add(value);
            return CreatedAtRoute("Get", new { controller = "ACLPermissions", id = value.ID }, value);
        }

        // PUT api/aclpermissions/5
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

        // DELETE api/aclpermissions/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryTokenAttribute]
        public void Delete(int id)
        {
            ACLPermission permission = _context.ACLPermissions.Single(m => m.ID == id);
            _context.ACLPermissions.Remove(permission);
            _context.SaveChanges();
        }
        
    }
}