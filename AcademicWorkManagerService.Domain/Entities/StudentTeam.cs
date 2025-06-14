using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
    public class StudentTeam
    {
        public int Id { get; set; }
        public int? ThemeId { get; set; }
        public Theme Theme { get; set; }
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public ICollection<TeamMember> Members { get; set; } = new List<TeamMember>();
    }
}
