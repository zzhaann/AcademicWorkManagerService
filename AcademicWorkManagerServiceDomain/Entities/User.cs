using AcademicWorkManagerService.Domain.Enums;

namespace AcademicWorkManagerService.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }  
        public UserRoles Roles { get; set; }


    }
}
