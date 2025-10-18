using System.ComponentModel.DataAnnotations;

namespace LibraryMongo.Models.DTOs;

public class CreateUserDTO
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
