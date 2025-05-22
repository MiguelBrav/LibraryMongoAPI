using LibraryMongo.Models.Entities;

namespace LibraryMongo.Models.Responses;

public class RoleResponse
{
    public string Id { get; set; } = string.Empty;
    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();

    public RoleResponse() { }

    public RoleResponse(Role role)
    {
        Id = role.Id.ToString();
        Name = role.Name;
    }
}

