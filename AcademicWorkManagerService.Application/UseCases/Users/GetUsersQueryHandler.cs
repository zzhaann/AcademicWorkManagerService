using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicWorkManagerService.Domain.Constants;
using KDS.Primitives.FluentResult;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public class GetUsersQueryHandler(IUserService userService) : IRequestHandler<GetUsersQuery, Result<UserDTO[]>>
    {

        public async Task<Result<UserDTO[]>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await userService.GetAllAsync();
            
            if (result.IsFailed)
                return Result.Failure<UserDTO[]>(new Error(ErrorCode.NotFound, "Пользователей нет."));

            return result;
        }
    }
}
