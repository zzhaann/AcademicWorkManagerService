using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
    public class ThemeApprovalFlow
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }
        public int ApprovedByUserId { get; set; }
        public User ApprovedByUser { get; set; }
        public string ApprovedByRole { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
