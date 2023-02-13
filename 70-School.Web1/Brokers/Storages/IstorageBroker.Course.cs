using _70_School.Web1.Models.Course;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<Course> InsertCourseAsync(Course course);
        IQueryable<Course> SelectAllCourses();
        ValueTask<Course> SelectCourseByIdAsync(Guid courseId);
        ValueTask<Course> UpdateCourseAsync(Course course);
        ValueTask<Course> DeleteCourseAsync(Course course);
    }
}
