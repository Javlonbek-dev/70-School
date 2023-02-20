using _70_School.Web1.Models.Students;
using _70_School.Web1.Models.Students.Exceptions;

namespace _70_School.Web1.Services.Foundations.Students
{
    public partial class StudentService
    {
        private static void ValidateStudentNotNull(Student student)
        {
            if (student is null)
            {
                throw new NullStudentException();
            }
        }
    }
}
