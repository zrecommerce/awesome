using System.Collections.Generic;

namespace AwesomeAPI.Models
{
    public class ACLRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public bool Enabled { get; set; }
        public List<ACLPermission> Permissions { get; set; }
    }
}