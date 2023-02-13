using _70_School.Web1.Models.Course;
using System.Linq;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<Course> InsertCourseAsync(Course course);
        IQueryable<Course> SelectAllCourses();
    }
}
