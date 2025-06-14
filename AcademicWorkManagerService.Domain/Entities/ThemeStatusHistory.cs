using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
    public class ThemeStatusHistory
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }

        public int OldStatusId { get; set; }
        public int NewStatusId { get; set; }
        public DateTime ChangedAt { get; set; }
        public int ChangedByUserId { get; set; }
        public User ChangedByUser { get; set; }
        public string Comment { get; set; }
    }
}
