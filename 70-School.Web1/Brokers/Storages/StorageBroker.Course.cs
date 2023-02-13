using _70_School.Web1.Models.Course;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<Course> InsertCourseAsync(Course course)=>
            await InsertAsync(course);

        public IQueryable<Course> SelectAllCourses() =>
            SelectAll<Course>();

        public async ValueTask<Course> SelectCourseByIdAsync(Guid courseId) =>
            await SelectAsync<Course>(courseId);

        public async ValueTask<Course> UpdateCourseAsync(Course course)=>
            await UpdateAsync(course);

        public async ValueTask<Course> DeleteCourseAsync(Course course)=>
            await DeleteAsync<Course>(course);
    }
}
