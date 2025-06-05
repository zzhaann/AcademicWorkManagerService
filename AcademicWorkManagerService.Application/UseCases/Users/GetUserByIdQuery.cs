using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public record GetUserByIdQuery(int Id) : IRequest<Result<UserDTO?>>;
}
