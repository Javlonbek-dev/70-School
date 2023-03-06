using System;
using Xeptions;

namespace _70_School.Web1.Models.Students.Exceptions
{
    public class FailedStudentServiceException:Xeption
    {
        public FailedStudentServiceException(Exception innerException)
            :base(message: "Failed post service occured, please contact support",innerException)
        {}
    }
}
