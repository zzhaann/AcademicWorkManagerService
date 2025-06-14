namespace AcademicWorkManagerService.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<TeamMember> TeamMemberships { get; set; } = new List<TeamMember>();
        public ICollection<StudentTeam> CreatedTeams { get; set; } = new List<StudentTeam>();
        public ICollection<Theme> CreatedThemes { get; set; } = new List<Theme>();
        public ICollection<Theme> SupervisedThemes { get; set; } = new List<Theme>();

    }
}
