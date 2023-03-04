using System;
using Xeptions;

namespace _70_School.Web1.Models.Students.Exceptions
{
    public class StudentServiceException:Xeption
    {
        public StudentServiceException(Exception innerException)
            :base(message: "Comment service error occurred, contact support.",innerException)
        { }
    }
}
