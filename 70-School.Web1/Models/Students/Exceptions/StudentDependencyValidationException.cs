using System;
using Xeptions;

namespace _70_School.Web1.Models.Students.Exceptions
{
    public class StudentDependencyValidationException:Xeption
    {
        public StudentDependencyValidationException(Xeption innerException)
            :base(message: "Student dependency validation occured, please try again.",innerException)
        { }
    }
}
