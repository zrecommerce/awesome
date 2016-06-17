using System.Collections.Generic;

namespace AwesomeCore.Models
{
    public class Channel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IdentityUser> Whitelist { get; set; }
        public List<IdentityUser> Blacklist { get; set; }
        public bool Visibility { get; set; }
        public IdentityUser Owner { get; set; }
    }
}