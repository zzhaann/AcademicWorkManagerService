﻿using AcademicWorkManagerService.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;
using System.Text.Json.Serialization;

namespace AcademicWorkManagerService.Application.UseCases.Users
{
    public class CreateUserCommand : IRequest<Result<UserDTO>>
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; } = string.Empty;

        [JsonPropertyName("roleId")]
        public int RoleId { get; set; }
    }
}
