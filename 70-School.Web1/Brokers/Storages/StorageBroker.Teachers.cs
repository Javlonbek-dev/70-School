using _70_School.Web1.Models.Teachers;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<Teacher> InsertTeacherAsync(Teacher teacher) =>
            await InsertAsync(teacher);

        public IQueryable<Teacher> SelectAllTeachers() =>
            SelectAll<Teacher>();

        public async ValueTask<Teacher> SelectTeacherByIdAsync(Guid Id) =>
            await SelectAsync<Teacher>(Id);

        public async ValueTask<Teacher> UpdateTeacherAsync(Teacher teacher) =>
            await UpdateAsync(teacher);
    }
}
