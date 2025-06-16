using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;
using System.Text.Json.Serialization;

namespace AcademicWorkManagerService.Application.UseCases.StudentAlones
{
    public class CreateStudentAloneCommand : IRequest<Result<StudentAloneDTO>>
    {
        [JsonPropertyName("studentId")]
        public int StudentId { get; set; }

        [JsonPropertyName("themeId")]
        public int ThemeId { get; set; }
    }
}
