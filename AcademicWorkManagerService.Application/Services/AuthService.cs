// AcademicWorkManagerService.Application/Services/AuthService.cs
using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Domain.Constants;
using AcademicWorkManagerService.Domain.Entities;
using KDS.Primitives.FluentResult;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace AcademicWorkManagerService.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<Result<AuthResponseDTO>> LoginAsync(LoginDTO loginDto)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(loginDto.UserName);

            if (user == null)
            {
                return Result.Failure<AuthResponseDTO>(new Error(ErrorCode.Unauthorized, "Неверное имя пользователя или пароль"));
            }

            bool isPasswordValid = BC.Verify(loginDto.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                return Result.Failure<AuthResponseDTO>(new Error(ErrorCode.Unauthorized, "Неверное имя пользователя или пароль"));
            }

            var token = GenerateJwtToken(user);

            return new AuthResponseDTO
            {
                Token = token,
                UserName = user.UserName,
                UserRole = user.UserRole,
                UserId = user.Id
            };
        }

        public async Task<Result<AuthResponseDTO>> RegisterAsync(RegisterDTO registerDto)
        {
            var existingUser = await _unitOfWork.Users.GetByUsernameAsync(registerDto.UserName);

            if (existingUser != null)
            {
                return Result.Failure<AuthResponseDTO>(new Error(ErrorCode.Conflict, "Пользователь с таким именем уже существует"));
            }

            string passwordHash = BC.HashPassword(registerDto.Password);

            var user = new User
            {
                UserName = registerDto.UserName,
                UserRole = registerDto.UserRole,
                PasswordHash = passwordHash
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            var token = GenerateJwtToken(user);

            return new AuthResponseDTO
            {
                Token = token,
                UserName = user.UserName,
                UserRole = user.UserRole,
                UserId = user.Id
            };
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT key is not configured"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.UserRole)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
