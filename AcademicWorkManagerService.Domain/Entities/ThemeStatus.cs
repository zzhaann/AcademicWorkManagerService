using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
    public class ThemeStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Theme> Themes { get; set; } = new List<Theme>();
    }
}
