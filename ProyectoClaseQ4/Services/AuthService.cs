
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Google.Cloud.Firestore;
using Microsoft.IdentityModel.Tokens;
using ProyectoClaseQ4.DTOs;
using ProyectoClaseQ4.Models;


namespace ProyectoClaseQ4.Services
{
    public class AuthService : IAuthService
    {
        private readonly FirebaseServices _firebaseService;
        private readonly IConfiguration _configuration;

        public AuthService(FirebaseServices firebaseService, IConfiguration configuration)
        {
            _firebaseService = firebaseService;
            _configuration = configuration;
        }
        
        //Register
        public async Task<AuthResponseDto> Register(RegisterDto registerdto)
        {
            try
            {
                //1. Verificar si el usuario ya existe
                var exisingUser = await GetUserByEmail(registerdto.Email);

                if (exisingUser != null)
                {
                    throw new Exception("User with this email already exists");
                }
                
                //2. Generar un ID unico para el usuario
                var userId = Guid.NewGuid().ToString();
                
                //3. Hashear la password
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerdto.Password);
                
                //4. Crear documento de usuario en Firestore
                var user = new User
                {
                    Id = userId,
                    Email = registerdto.Email,
                    Fullname = registerdto.FullName,
                    Role = "user",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                };
                
                var usersCollection = _firebaseService.GetCollection("users");
                
                // Guardar usuario con el password hasheado

                var userData = new Dictionary<string, object>()
                {
                    {"Id", user.Id},
                    {"Email", user.Email},
                    {"Fullname", user.Fullname},
                    {"Role", user.Role},
                    {"CreatedAt", user.CreatedAt},
                    {"IsActive", user.IsActive},
                    {"PasswordHash", passwordHash}
                };

                await usersCollection.Document(user.Id).SetAsync(userData);
                
                // 5. Generar token JWT
                var token = GenerateJwtToken(user);
                
                //6. Retornar respuestas
                return new AuthResponseDto
                {
                    Token = token,
                    UserId = user.Id,
                    Email = user.Email,
                    FullName = user.Fullname,
                    Role = user.Role
                };

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al registrar usuario: {ex.Message}");
            }
        }
    }
}