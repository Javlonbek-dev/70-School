using _70_School.Web1.Models.Students;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<Student> InsertStudentAsync(Student student);
    }
}
