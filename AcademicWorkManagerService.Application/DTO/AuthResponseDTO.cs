﻿namespace AcademicWorkManagerService.Application.DTO
{
    public class AuthResponseDTO
    {
        public string Token { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public int UserId { get; set; }
    }
}
