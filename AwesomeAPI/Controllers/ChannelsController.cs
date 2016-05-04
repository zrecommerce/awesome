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
    public class ChannelsController : Controller
    {
        private AwesomeContext _context;
        
        public ChannelsController(AwesomeContext context)
        {
            _context = context;
        }
        
        // GET: api/channels
        [HttpGet]
        public IEnumerable<Channel> Get()
        {
            return _context.Channels.ToList();
        }
        
        // GET api/channels/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Channel result;
            
            try {
                result = _context.Channels.Single(m => m.ID == id);
                
                if (result == null)
                {
                    return HttpNotFound();
                }
                return new ObjectResult(result);
            } catch (InvalidOperationException ) {
                return HttpNotFound();
            }
        }
        
        // POST api/channels
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Post([FromBody]Channel value)
        {
            if (value == null)
            {
                return HttpBadRequest();
            }
            _context.Channels.Add(value);
            return CreatedAtRoute("Get", new { controller = "Channels", id = value.ID }, value);
        }
        
        // PUT api/channels/5
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
        
        // DELETE api/channels/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryTokenAttribute]
        public void Delete(int id)
        {
            Channel resource = _context.Channels.Single(m => m.ID == id);
            _context.Channels.Remove(resource);
            _context.SaveChanges();
        }
    }
}