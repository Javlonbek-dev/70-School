using _70_School.Web1.Models.Course;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<Course> InsertCourseAsync(Course course)=>
            await InsertAsync(course);
    }
}
