using System;
using Xeptions;

namespace _70_School.Web1.Models.Students.Exceptions
{
    public class FailedStudentStorageException : Xeption
    {
        public FailedStudentStorageException(Exception innerException)
            : base(message: "Failed post storage error occurred, contact support.", innerException)
        { }
    }
}
