using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeCore.Models
{
    public static class AwesomeAPIExtension
    {
        public static void EnsureSeedData(this AwesomeContext context)
        {
            if (!context.ACLPermissions.Any())
            {
                context.ACLPermissions.Add(new ACLPermission{ ID = 1, Name = "read" });
                context.ACLPermissions.Add(new ACLPermission{ ID = 2, Name = "write" });
                context.ACLPermissions.Add(new ACLPermission{ ID = 3, Name = "execute" });
                
                context.SaveChanges();
            }
            
            if (!context.ACLRoles.Any())
            {
                context.ACLRoles.Add(new ACLRole{ ID = 1, Name = "user"});
                context.ACLRoles.Add(new ACLRole{ ID = 2, Name = "moderator"});
                
                context.SaveChanges();
            }
            
            
            
            if (!context.MessageTypes.Any())
            {
                context.MessageTypes.Add(new MessageType{ ID = 1, Name = "text" });
                context.MessageTypes.Add(new MessageType{ ID = 2, Name = "video" });
                context.MessageTypes.Add(new MessageType{ ID = 3, Name = "image" });
                context.MessageTypes.Add(new MessageType{ ID = 4, Name = "file" });
                
                context.SaveChanges();
            }
            
            if (!context.UserStatuses.Any())
            {
                context.UserStatuses.Add(new UserStatus{ ID = 1, Name = "online" });
                context.UserStatuses.Add(new UserStatus{ ID = 2, Name = "away" });
                context.UserStatuses.Add(new UserStatus{ ID = 3, Name = "busy" });
                context.UserStatuses.Add(new UserStatus{ ID = 4, Name = "offline" });
                context.UserStatuses.Add(new UserStatus{ ID = 5, Name = "mobile" });
                
                context.SaveChanges();
            }
            
            if (!context.IdentityUsers.Any())
            {
                context.IdentityUsers.Add(new IdentityUser{ ID = 1, Handle = "Admin", Name = "System Admin", Email = "support@localhost", Role = context.ACLRoles.Single(m => m.ID == 2), Status = context.UserStatuses.Single(m => m.ID == 4) });
                
                context.SaveChanges();
            }
        }
    }
}