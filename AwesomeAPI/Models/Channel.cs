using System.Collections.Generic;

namespace AwesomeAPI.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IdentityUser> Whitelist { get; set; }
        public List<IdentityUser> Blacklist { get; set; }
        public bool Visibility { get; set; }
        public IdentityUser Owner { get; set; }
    }
}