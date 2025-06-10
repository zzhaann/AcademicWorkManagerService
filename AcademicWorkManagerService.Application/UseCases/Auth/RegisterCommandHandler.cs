using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using AcademicWorkManagerService.Domain.Constants;
using KDS.Primitives.FluentResult;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.UseCases.Auth
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthResponseDTO>>
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<AuthResponseDTO>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(request.RoleId);
            if (role == null)
            {
                return Result.Failure<AuthResponseDTO>(new Error(ErrorCode.NotFound, $"Роль с ID {request.RoleId} не найдена."));
            }

            var registerDto = new RegisterDTO
            {
                UserName = request.UserName,
                Password = request.Password,
                RoleId = request.RoleId
            };

            var result = await _authService.RegisterAsync(registerDto);
            
            if (result.IsFailed)
                return result;
            
            result.Value.RoleName = role.Name;

            return result;
        }
    }
}
