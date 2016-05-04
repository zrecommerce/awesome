using System.Collections.Generic;

namespace AwesomeAPI.Models
{
    public class IdentityUser
    {
        public int Id { get; set; }
        public string Handle { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }
        public ACLRole Role { get; set; }
        public List<Message> Messages { get; set; }
        public UserStatus Status { get; set; }
        
    }
}