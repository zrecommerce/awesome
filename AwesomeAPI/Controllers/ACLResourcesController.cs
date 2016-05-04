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
    public class ACLResourcesController : Controller
    {
        private AwesomeContext _context;
        
        public ACLResourcesController(AwesomeContext context)
        {
            _context = context;
        }
        
        // GET: api/aclresources
        [HttpGet]
        public IEnumerable<ACLResource> Get()
        {
            return _context.ACLResources.ToList();
        }
        
        // GET api/aclresources/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ACLResource result;
            
            try {
                result = _context.ACLResources.Single(m => m.ID == id);
                
                if (result == null)
                {
                    return HttpNotFound();
                }
                return new ObjectResult(result);
            } catch (InvalidOperationException ) {
                return HttpNotFound();
            }
        }
        
        // POST api/aclresources
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Post([FromBody]ACLResource value)
        {
            if (value == null)
            {
                return HttpBadRequest();
            }
            _context.ACLResources.Add(value);
            return CreatedAtRoute("Get", new { controller = "ACLResources", id = value.ID }, value);
        }
        
        // PUT api/aclresources/5
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
        
        // DELETE api/aclresources/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryTokenAttribute]
        public void Delete(int id)
        {
            ACLResource resource = _context.ACLResources.Single(m => m.ID == id);
            _context.ACLResources.Remove(resource);
            _context.SaveChanges();
        }
        
    }
}