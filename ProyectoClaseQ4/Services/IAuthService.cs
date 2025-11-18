
using ProyectoClaseQ4.DTOs;
using ProyectoClaseQ4.Models;

namespace ProyectoClaseQ4.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(RegisterDto registerdto);
        Task<AuthResponseDto> Login(LoginDto logindto);
        Task<User?> GetUserById(string userId);
        Task<User?> GetUserByEmail(string email);
        string GenerateJwtToken(User user);
    }
}