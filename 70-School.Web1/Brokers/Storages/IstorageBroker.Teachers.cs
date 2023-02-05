using _70_School.Web1.Models.Teachers;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<Teacher> InsertTeacherAsync(Teacher teacher);
        ValueTask<Teacher> UpdateTeacherAsync(Teacher teacher);
    }
}
