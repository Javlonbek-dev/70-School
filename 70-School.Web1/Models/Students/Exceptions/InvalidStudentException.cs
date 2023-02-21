using Xeptions;

namespace _70_School.Web1.Models.Students.Exceptions
{
    public class InvalidStudentException : Xeption
    {
        public InvalidStudentException()
            : base(message: "Student is invalid.")
        { }

    }
}
