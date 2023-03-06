using Xeptions;

namespace _70_School.Web1.Models.Students.Exceptions
{
    public class StudentValidationException : Xeption
    {
        public StudentValidationException(Xeption innerException)
            : base(message: "User validation error occured, fix the errors and try again", innerException)
        { }

    }
}
