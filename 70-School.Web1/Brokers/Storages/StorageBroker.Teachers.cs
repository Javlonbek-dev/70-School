using _70_School.Web1.Models.Teachers;
using System;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<Teacher> InsertTeacherAsync(Teacher teacher) =>
            await InsertAsync(teacher);

        public async ValueTask<Teacher> SelectTeacherByIdAsync(Guid Id) =>
            await SelectAsync<Teacher>(Id);
    }
}
