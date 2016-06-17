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
    
    public class MessagesController : Controller
    {
        private AwesomeContext _context;
        
        public MessagesController(AwesomeContext context)
        {
            _context = context;
        }
        
        // GET: api/messages
        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return _context.Messages.ToList();
        }
        
        // GET api/messages/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Message result;
            
            try {
                result = _context.Messages.Single(m => m.ID == id);
                
                if (result == null)
                {
                    return NotFound();
                }
                return new ObjectResult(result);
            } catch (InvalidOperationException ) {
                return NotFound();
            }
        }
        
        // POST api/messages
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Post([FromBody]Message value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            _context.Messages.Add(value);
            return CreatedAtRoute("Get", new { controller = "Messages", id = value.ID }, value);
        }
        
        // PUT api/messages/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryTokenAttribute]
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
        
        // DELETE api/messages/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryTokenAttribute]
        public void Delete(int id)
        {
            Message resource = _context.Messages.Single(m => m.ID == id);
            _context.Messages.Remove(resource);
            _context.SaveChanges();
        }
    }
}