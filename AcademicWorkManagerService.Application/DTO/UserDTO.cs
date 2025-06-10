using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.DTO
{
   public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
    }
}
