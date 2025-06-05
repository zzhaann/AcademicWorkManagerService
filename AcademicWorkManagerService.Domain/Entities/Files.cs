using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
    public class Files
    {
        public int Id { get; set; }
        public byte[] Data { get; set; } = null!;

        public int DiplomaId { get; set; }
        public Diploma Diploma { get; set; } = null!;
    }
}
