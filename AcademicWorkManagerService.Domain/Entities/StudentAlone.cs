using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
    public class StudentAlone
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }
    }
}
