using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;
using System.Text.Json.Serialization;

namespace AcademicWorkManagerService.Application.UseCases.StudentAlones
{
    public record UpdateStudentAloneCommand : IRequest<Result<StudentAloneDTO>>
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("themeId")]
        public int ThemeId { get; init; }
    }
}
