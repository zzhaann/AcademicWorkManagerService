using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Domain.Constants;
using AcademicWorkManagerService.Domain.Entities;
using KDS.Primitives.FluentResult;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<UserDTO[]>> GetAllAsync()
        {
            // Make sure to include the Role relationship when fetching users
            var users = await _unitOfWork.Users.GetAllWithRolesAsync();

            if (!users.Any())
            {
                return Result.Failure<UserDTO[]>(new Error(ErrorCode.NotFound, "Пользователей нет."));
            }

            var userDtos = users.Select(u => new UserDTO
            {
                Id = u.Id,
                UserName = u.UserName,
                RoleId = u.RoleId,
                RoleName = u.Role?.Name ?? string.Empty
            }).ToArray();

            return userDtos;
        }

        public async Task<Result<UserDTO?>> GetByIdAsync(int id)
        {
            // Make sure to include the Role relationship when fetching a user by ID
            var user = await _unitOfWork.Users.GetByIdWithRoleAsync(id);

            if (user == null)
            {
                return Result.Failure<UserDTO?>(new Error(ErrorCode.NotFound, $"Пользователь с ID {id} не найден."));
            }

            var userDto = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                RoleId = user.RoleId,
                RoleName = user.Role?.Name ?? string.Empty
            };

            return userDto;
        }

        public async Task<Result<UserDTO?>> GetByUsernameAsync(string username)
        {
            // Make sure to include the Role relationship when fetching a user by username
            var user = await _unitOfWork.Users.GetByUsernameWithRoleAsync(username);

            if (user == null)
            {
                return Result.Failure<UserDTO?>(new Error(ErrorCode.NotFound, $"Пользователь с именем {username} не найден."));
            }

            var userDto = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                RoleId = user.RoleId,
                RoleName = user.Role?.Name ?? string.Empty
            };

            return userDto;
        }

        public async Task<Result<UserDTO>> CreateAsync(UserDTO userDto)
        {
            var existingUser = await _unitOfWork.Users.GetByUsernameAsync(userDto.UserName);
            if (existingUser != null)
            {
                return Result.Failure<UserDTO>(new Error(ErrorCode.Conflict, "Пользователь с таким именем уже существует."));
            }

            // Check if the role exists
            var role = await _unitOfWork.Roles.GetByIdAsync(userDto.RoleId);
            if (role == null)
            {
                return Result.Failure<UserDTO>(new Error(ErrorCode.NotFound, $"Роль с ID {userDto.RoleId} не найдена."));
            }

            var user = new User
            {
                UserName = userDto.UserName,
                RoleId = userDto.RoleId
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            // Get the newly created user with the role
            var createdUser = await _unitOfWork.Users.GetByIdWithRoleAsync(user.Id);
            if (createdUser == null)
            {
                return Result.Failure<UserDTO>(new Error(ErrorCode.NotFound, "Ошибка при получении созданного пользователя."));
            }

            userDto.Id = createdUser.Id;
            userDto.RoleName = createdUser.Role?.Name ?? string.Empty;
            
            return userDto;
        }

        public async Task<Result<UserDTO>> UpdateAsync(int id, UserDTO userDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                return Result.Failure<UserDTO>(new Error(ErrorCode.NotFound, $"Пользователь с ID {id} не найден."));
            }

            var existingUser = await _unitOfWork.Users.GetByUsernameAsync(userDto.UserName);
            if (existingUser != null && existingUser.Id != id)
            {
                return Result.Failure<UserDTO>(new Error(ErrorCode.Conflict, "Пользователь с таким именем уже существует."));
            }

            // Check if the role exists
            var role = await _unitOfWork.Roles.GetByIdAsync(userDto.RoleId);
            if (role == null)
            {
                return Result.Failure<UserDTO>(new Error(ErrorCode.NotFound, $"Роль с ID {userDto.RoleId} не найдена."));
            }

            user.UserName = userDto.UserName;
            user.RoleId = userDto.RoleId;

            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            // Get the updated user with the role
            var updatedUser = await _unitOfWork.Users.GetByIdWithRoleAsync(id);
            if (updatedUser == null)
            {
                return Result.Failure<UserDTO>(new Error(ErrorCode.NotFound, "Ошибка при получении обновленного пользователя."));
            }

            userDto.Id = updatedUser.Id;
            userDto.RoleName = updatedUser.Role?.Name ?? string.Empty;
            
            return userDto;
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                return Result.Failure<bool>(new Error(ErrorCode.NotFound, $"Пользователь с ID {id} не найден."));
            }

            await _unitOfWork.Users.RemoveAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
