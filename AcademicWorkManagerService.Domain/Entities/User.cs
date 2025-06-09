using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; } 
        public string UserRole { get; set; } 

    }
}
