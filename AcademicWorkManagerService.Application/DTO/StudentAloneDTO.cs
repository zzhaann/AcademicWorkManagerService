using AcademicWorkManagerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicWorkManagerService.Application.DTO
{
    public class StudentAloneDTO
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }
        public int StudentId { get; set; }
    }
}
