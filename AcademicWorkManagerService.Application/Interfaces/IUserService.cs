using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO[]> GetAllAsync();
        Task<UserDTO?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
    }
}
