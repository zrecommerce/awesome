MODELS
======

*Draft 0.0.1*

This document contains a map of the data models and relationships used by the AwesomeAPI service.
All end-points are documented using Swagger (via Swashbuckle).

Note: EF 7 data seeding happens in `Models/AwesomeExtension.cs`

*Update the default IdentityUser entry with your own e-mail!*

## ACL

  * ACLRole - id, name, weight, enabled, permissions (List<ACLPermission>)
                            [{id: 1, name: "user"}, {id: 2, name: "moderator"}]
  * ACLResource - id, name, requiredRoles (List<ACLRole>), requiredPermissions (List<ACLPermission>)
  * ACLPermission - id, name
                            [{id: 1, name: "read"}, {id: 2, name: "write"}, {id: 3, name: "execute"}]

## User
 * IdentityUser - id, handle, name, email, enabled, role (ACLRole), messages (List<Message>), status (UserStatus), avatar, password_hash, activation_hash
                            [{id: 1, handle: "Admin", name: "System Admin", email: "support@localhost", role: ACLRole#2, status: UserStatus#4}]
 * UserStatus - id, name
                            [{id: 1, name: "online"}, {id: 2, name: "away"}, {id: 3, name: "busy"}, {id: 4, name: "offline"}, {id: 5, name: "mobile"}]

## Chat
 * Channel - id, name, description, whitelist (List<IdentityUser>), blacklist (List<IdentityUser>), visibility, owner, messages (List<Message>)
 * Message - id, timestamp, type (MessageType), content
 * MessageType - id, name
                            [{id: 1, name: "text"}, {id: 2, name: "video"}, {id: 3, name: "image"}, {id: 4, name: "file"}]