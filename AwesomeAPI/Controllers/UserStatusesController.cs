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
    
    public class UserStatusesController : Controller
    {
        private AwesomeContext _context;
        
        public UserStatusesController(AwesomeContext context)
        {
            _context = context;
        }
        
        // GET: api/userstatuses
        [HttpGet]
        public IEnumerable<UserStatus> Get()
        {
            return _context.UserStatuses.ToList();
        }
        
        // GET api/userstatuses/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UserStatus result;
            
            try {
                result = _context.UserStatuses.Single(m => m.ID == id);
                
                if (result == null)
                {
                    return HttpNotFound();
                }
                return new ObjectResult(result);
            } catch (InvalidOperationException ) {
                return HttpNotFound();
            }
        }
        
        // POST api/userstatuses
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Post([FromBody]UserStatus value)
        {
            if (value == null)
            {
                return HttpBadRequest();
            }
            _context.UserStatuses.Add(value);
            return CreatedAtRoute("Get", new { controller = "UserStatuses", id = value.ID }, value);
        }
        
        // PUT api/userstatuses/5
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
        
        // DELETE api/userstatuses/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryTokenAttribute]
        public void Delete(int id)
        {
            UserStatus resource = _context.UserStatuses.Single(m => m.ID == id);
            _context.UserStatuses.Remove(resource);
            _context.SaveChanges();
        }
    }
}