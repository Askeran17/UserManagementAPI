using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models
{
public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public required string Email { get; set; }
}
}
