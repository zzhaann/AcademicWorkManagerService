using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Domain.Entities;
using KDS.Primitives.FluentResult;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<UserDTO[]>> GetAllAsync();
        Task<Result<UserDTO?>> GetByIdAsync(int id);
        Task<Result<UserDTO?>> GetByUsernameAsync(string username);
        Task<Result<UserDTO>> CreateAsync(UserDTO userDto);
        Task<Result<UserDTO>> UpdateAsync(int id, UserDTO userDto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
