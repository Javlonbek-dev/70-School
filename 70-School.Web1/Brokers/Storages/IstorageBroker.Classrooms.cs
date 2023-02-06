using _70_School.Web1.Models.Classrooms;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<Classroom> InsertClassroom(Classroom classroom);
        IQueryable<Classroom> SelectAllClassrooms();
        ValueTask<Classroom> SelectClasroomById(Guid Id);
        ValueTask<Classroom> UpdateClassroom(Classroom classroom);
        ValueTask<Classroom> DeleteClassroom(Classroom classroom);
    }
}
