using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.PlatformAbstractions;

namespace AwesomeCore.Models
{
    public class AwesomeContext : DbContext
    {
        public DbSet<ACLPermission> ACLPermissions { get; set; }
        public DbSet<ACLResource> ACLResources { get; set; }
        public DbSet<ACLRole> ACLRoles { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = PlatformServices.Default.Application.ApplicationBasePath;
            optionsBuilder.UseSqlite("Filename=" + Path.Combine(path, "awesome.db"));
            
        }
    }
}