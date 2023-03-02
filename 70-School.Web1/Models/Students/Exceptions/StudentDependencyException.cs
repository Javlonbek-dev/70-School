using Xeptions;

namespace _70_School.Web1.Models.Students.Exceptions
{
    public class StudentDependencyException : Xeption
    {
        public StudentDependencyException(Xeption innerException)
            : base(message: "Student dependency error occurred, contect support.", innerException)
        { }
    }
}
