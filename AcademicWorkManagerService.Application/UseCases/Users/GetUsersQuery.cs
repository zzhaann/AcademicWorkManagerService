using AcademicWorkManagerService.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public class GetUsersQuery : IRequest<UserDTO[]>
    {
    }
}
