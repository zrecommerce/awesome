using System.Collections.Generic;

namespace AwesomeAPI.Models
{
    public class ACLResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ACLRole> RequiredRole { get; set; }
        public List<ACLPermission> RequiredPermissions { get; set; }
    }
}