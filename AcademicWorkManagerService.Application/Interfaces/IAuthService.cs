using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Result<AuthResponseDTO>> LoginAsync(LoginDTO loginDto);
        Task<Result<AuthResponseDTO>> RegisterAsync(RegisterDTO registerDto);
    }
}
