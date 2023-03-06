using Xeptions;

namespace _70_School.Web1.Models.Students.Exceptions
{
    public class NullStudentException : Xeption
    {
        public NullStudentException()
            : base(message: "Student is null")
        { }
    }
}
