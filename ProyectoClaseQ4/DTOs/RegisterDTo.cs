
using System.ComponentModel.DataAnnotations;
namespace ProyectoClaseQ4.DTOs;

public class RegisterDTo
{
    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "El email es invalido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "El password es requerido")]
    [MinLength(6, ErrorMessage = "El password debe tener 6 caracteres")]
    public string Password { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El nombre completo es requerido")]
    public string FullName { get; set; }
}