using KDS.Primitives.FluentResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.UseCases.Theme
{
    public record DeleteThemeCommand(int id) : IRequest<Result<bool>>;
    
}
