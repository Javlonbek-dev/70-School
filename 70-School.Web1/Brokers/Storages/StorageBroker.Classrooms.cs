using _70_School.Web1.Models.Classrooms;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<Classroom> InsertClassroom(Classroom classroom) =>
            await InsertAsync(classroom);

        public IQueryable<Classroom> SelectAllClassrooms() =>
            SelectAll<Classroom>();

        public async ValueTask<Classroom> SelectClasroomById(Guid classroomId) =>
            await SelectAsync<Classroom>(classroomId);

        public async ValueTask<Classroom> UpdateClassroom(Classroom classroom) =>
            await UpdateAsync(classroom);

        public async ValueTask<Classroom> DeleteClassroom(Classroom classroom) =>
            await DeleteAsync(classroom);
    }
}
