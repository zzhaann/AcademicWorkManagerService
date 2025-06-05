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
            var users = await _unitOfWork.Users.GetAllAsync();

            if (!users.Any())
            {
                return Result.Failure<UserDTO[]>(new Error(ErrorCode.NotFound, "Пользователей нет."));
            }

            var userDtos = users.Select(u => new UserDTO
            {
                Id = u.Id,
                UserName = u.UserName,
                UserRole = u.UserRole
            }).ToArray();

            return userDtos;
        }

        public async Task<Result<UserDTO?>> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                return Result.Failure<UserDTO?>(new Error(ErrorCode.NotFound, $"Пользователь с ID {id} не найден."));
            }

            var userDto = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                UserRole = user.UserRole
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

            var user = new User
            {
                UserName = userDto.UserName,
                UserRole = userDto.UserRole
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            userDto.Id = user.Id;
            return userDto;
        }

        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            
            var user = await _context.users
                .Where(u => u.Id == (int)id)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    UserRole = u.UserRole
                })
                .FirstOrDefaultAsync();

            userDto.Id = user.Id;
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
