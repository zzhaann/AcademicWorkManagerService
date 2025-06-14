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
    public class CreateThemeCommand : IRequest<Result<ThemeDTO>>
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("workType")]
        public string WorkType { get; set; } = string.Empty;

        [JsonPropertyName("isStudentSuggested")]
        public bool IsStudentSuggested { get; set; }

        [JsonPropertyName("createdByUserId")]
        public int CreatedByUserId { get; set; }

        [JsonPropertyName("supervisorId")]
        public int SupervisorId { get; set; }



    }
}
