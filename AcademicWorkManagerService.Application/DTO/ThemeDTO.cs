using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.DTO
{
    public class ThemeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string WorkType { get; set; }
        public bool IsStudentSuggested { get; set; }
        public int CreatedByUserId { get; set; }
        public int SupervisorId { get; set; }
        public int StatusId { get; set; }
        public bool IsApprovedByDepartment { get; set; }
    }
}
