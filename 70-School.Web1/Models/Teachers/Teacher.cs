using _70_School.Web1.Models.Students;
using System;

namespace _70_School.Web1.Models.Teachers
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public TeacherStatus Status { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
    }
}

