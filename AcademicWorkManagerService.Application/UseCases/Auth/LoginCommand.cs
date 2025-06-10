using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;
using System.Text.Json.Serialization;

namespace AcademicWorkManagerService.Application.UseCases.Auth
{
    public class LoginCommand : IRequest<Result<AuthResponseDTO>>
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; } = null!;
        
        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;
    }
}
