using _70_School.Web1.Models.Students;
using System.Threading.Tasks;

namespace _70_School.Web1.Services.Foundations.Students
{
    public interface IStudentService
    {
        ValueTask<Student> AddStudentAsync(Student student);
    }
}