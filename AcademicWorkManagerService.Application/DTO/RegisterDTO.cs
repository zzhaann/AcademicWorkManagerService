using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.DTO
{
    public class RegisterDTO
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserRole { get; set; } = null!;
    }
}
