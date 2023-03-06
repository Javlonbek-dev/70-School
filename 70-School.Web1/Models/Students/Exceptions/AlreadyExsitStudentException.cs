using System;
using Xeptions;

namespace _70_School.Web1.Models.Students.Exceptions
{
    public class AlreadyExsitStudentException : Xeption
    {
        public AlreadyExsitStudentException(Exception innerException)
            : base(message: "Student with the same id already exists.", innerException)
        { }
    }
}
