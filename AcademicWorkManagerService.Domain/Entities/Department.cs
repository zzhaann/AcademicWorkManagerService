using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
