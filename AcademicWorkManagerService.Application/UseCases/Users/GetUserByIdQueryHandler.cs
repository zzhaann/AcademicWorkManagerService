using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public class GetUserByIdQueryHandler(IUserService userService) : IRequestHandler<GetUserByIdQuery, Result<UserDTO?>>
    {
        public async Task<Result<UserDTO?>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await userService.GetByIdAsync(request.Id);
            
            if (result.IsFailed)
                return Result.Failure<UserDTO?>(result.Error);

            return result;
        }
    }
}
