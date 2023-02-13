using _70_School.Web1.Models.Teachers;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<Teacher> InsertTeacherAsync(Teacher teacher);
        IQueryable<Teacher> SelectAllTeachers();
        ValueTask<Teacher> SelectTeacherByIdAsync(Guid teacherId);
        ValueTask<Teacher> UpdateTeacherAsync(Teacher teacher);
        ValueTask<Teacher> DeleteTeacherAsync(Teacher teacher);
    }
}
