using System.IO;
using Microsoft.Data.Entity;
using Microsoft.Extensions.PlatformAbstractions;
using AwesomeAPI.Models;

public class AppContext : DbContext
{
    public DbSet<ACLPermission> ACLPermissions { get; set; }
    public DbSet<ACLResource> ACLResources { get; set; }
    public DbSet<ACLRole> ACLRoles { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<IdentityUser> IdentityUsers { get; set; }
    public DbSet<Message> Messages { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var path = PlatformServices.Default.Application.ApplicationBasePath;
        optionsBuilder.UseSqlite("Filename=" + Path.Combine(path, "awesome.db"));
        
    }
}