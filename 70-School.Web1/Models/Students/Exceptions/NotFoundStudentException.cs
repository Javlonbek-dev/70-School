using System;
using Xeptions;

namespace _70_School.Web1.Models.Students.Exceptions
{
    public class NotFoundStudentException:Xeption
    {
        public NotFoundStudentException(Guid studentId)
            :base(message: $"Couldn't find postReport with id:{studentId}.")
        { }
    }
}
