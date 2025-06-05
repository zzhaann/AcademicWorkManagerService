using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
    public  class Theme
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public ICollection<Diploma> Diplomas { get; set; } = new List<Diploma>();
    }
}
