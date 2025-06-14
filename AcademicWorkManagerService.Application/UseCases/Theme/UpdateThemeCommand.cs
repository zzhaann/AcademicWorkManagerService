using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.UseCases.Theme
{
    public record UpdateThemeCommand : IRequest<Result<ThemeDTO>>
    {
        [JsonIgnore]
        public int Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string WorkType { get; init; } = string.Empty;
        public bool IsStudentSuggested { get; init; }
        public int SupervisorId { get; init; }
        public int StatusId { get; init; }
        public bool IsApprovedByDepartment { get; init; }
    }
}
