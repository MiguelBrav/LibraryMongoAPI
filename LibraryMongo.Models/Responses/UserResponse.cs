using LibraryMongo.Models.Entities;

namespace LibraryMongo.Models.Responses;

public class UserResponse
{
    public string Id { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public RoleResponse RolName { get; set; } = new RoleResponse(); 
    public bool IsBanned { get; set; }
}

