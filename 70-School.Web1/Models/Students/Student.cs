using System;

namespace _70_School.Web1.Models.Students
{
    public class Student
    {
        public Guid Id { get; set; }
        public string IdentityNumber { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public GenderType Gender { get; set; }
        public DateTimeOffset CraeteDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
