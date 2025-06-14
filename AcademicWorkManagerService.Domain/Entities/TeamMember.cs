using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
    public class TeamMember
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public StudentTeam Team { get; set; }

        public int StudentId { get; set; }
        public User Student { get; set; }
    }
}
