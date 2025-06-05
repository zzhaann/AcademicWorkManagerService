using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
   public class Diploma
    {
        public int Id { get; set; }

        public int ThemeId { get; set; }
        public Theme Theme { get; set; } = null!;

        public int StudentId { get; set; }
        public User Student { get; set; } = null!;

        public ICollection<Files> Files { get; set; } = new List<Files>();

    }
}
