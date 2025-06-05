using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Domain.Entities
{
    public class User
    {
        public int id { get; set; }

        public string userName { get; set; } 
        public string userRole { get; set; } 

    }
}
