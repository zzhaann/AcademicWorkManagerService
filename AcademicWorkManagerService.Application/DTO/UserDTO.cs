using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.DTO
{
   public class UserDTO
    {
        public int id { get; set; }

        public string userName { get; set; } = null!;
        public string userRole { get; set; } = null!;
    }
}
