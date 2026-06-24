using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MinLength(2, ErrorMessage = "Name must have at least 2 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = string.Empty;

    [Range(1, 120, ErrorMessage = "Age must be between 1 and 120.")]
    public int Age { get; set; }
}