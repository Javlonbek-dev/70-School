using _70_School.Web1.Models.Teachers;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<Teacher> InsertTeacherAsync(Teacher teacher) =>
            await InsertAsync(teacher);

        public async ValueTask<Teacher> UpdateTeacherAsync(Teacher teacher) =>
            await UpdateAsync(teacher);
    }
}
