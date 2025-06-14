using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
    public class Theme
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string WorkType { get; set; }
        public bool IsStudentSuggested { get; set; }
        public bool IsApprovedByDepartment { get; set; }

        public int StatusId { get; set; }
        public ThemeStatus Status { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int SupervisorId { get; set; }
        public User Supervisor { get; set; }

        public ICollection<ThemeStatusHistory> StatusHistory { get; set; } = new List<ThemeStatusHistory>();
        public ICollection<ThemeApprovalFlow> ApprovalFlow { get; set; } = new List<ThemeApprovalFlow>();
        public ICollection<ThemeFile> Files { get; set; } = new List<ThemeFile>();
    }
}
