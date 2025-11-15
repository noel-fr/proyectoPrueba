
using System.ComponentModel.DataAnnotations;
namespace ProyectoClaseQ4.DTOs;

public class LoginDTo
{
    [Required(ErrorMessage ="El email es requerido")]
    [EmailAddress(ErrorMessage ="El email es invalido")]
    public string Email { get; set; }
 
    [Required(ErrorMessage = "El password es requerido")]
    public string Password { get; set; } = string.Empty;
}