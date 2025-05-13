namespace LibraryMongo.Models.DTOs;

public class CreateRoleDTO
{
    public Dictionary<string, string> Name { get; set; } = new Dictionary<string, string>();
}
