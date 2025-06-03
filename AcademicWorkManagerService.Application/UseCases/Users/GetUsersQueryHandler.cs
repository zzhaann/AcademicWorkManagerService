using AcademicWorkManagerService.Application.DTO;
using AcademicWorkManagerService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public class GetUsersQueryHandler(IUserService userService) : IRequestHandler<GetUsersQuery, UserDTO[]>
    {

        public async Task<UserDTO[]> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await userService.GetAllAsync();
        }
    }
}
