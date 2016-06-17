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
    
    public class MessageTypesController : Controller
    {
        private AwesomeContext _context;
        
        public MessageTypesController(AwesomeContext context)
        {
            _context = context;
        }
        
        // GET: api/messagetypes
        [HttpGet]
        public IEnumerable<MessageType> Get()
        {
            return _context.MessageTypes.ToList();
        }
        
        // GET api/messagetypes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            MessageType result;
            
            try {
                result = _context.MessageTypes.Single(m => m.ID == id);
                
                if (result == null)
                {
                    return NotFound();
                }
                return new ObjectResult(result);
            } catch (InvalidOperationException ) {
                return NotFound();
            }
        }
        
        // POST api/messagetypes
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Post([FromBody]MessageType value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            _context.MessageTypes.Add(value);
            return CreatedAtRoute("Get", new { controller = "MessageTypes", id = value.ID }, value);
        }
        
        // PUT api/messagetypes/5
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
        
        // DELETE api/messagetypes/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryTokenAttribute]
        public void Delete(int id)
        {
            MessageType resource = _context.MessageTypes.Single(m => m.ID == id);
            _context.MessageTypes.Remove(resource);
            _context.SaveChanges();
        }
    }
}