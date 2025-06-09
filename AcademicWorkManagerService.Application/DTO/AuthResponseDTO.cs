using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.DTO
{
    public class AuthResponseDTO
    {
        public string Token { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public int UserId { get; set; }
    }
}
