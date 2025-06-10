using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.UseCases.Auth
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthResponseDTO>>
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public LoginCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<AuthResponseDTO>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginDto = new LoginDTO
            {
                UserName = request.UserName,
                Password = request.Password
            };

            var result = await _authService.LoginAsync(loginDto);
            
            if (result.IsFailed)
                return result;

            // Retrieve role name based on role ID
            if (result.Value.RoleId > 0)
            {
                var role = await _unitOfWork.Roles.GetByIdAsync(result.Value.RoleId);
                if (role != null)
                {
                    result.Value.RoleName = role.Name;
                }
            }

            return result;
        }
    }
}
