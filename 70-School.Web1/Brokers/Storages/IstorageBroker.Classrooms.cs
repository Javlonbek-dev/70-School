using _70_School.Web1.Models.Classrooms;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<Classroom> InsertClassroom(Classroom classroom);
        ValueTask<Classroom> UpdateClassroom(Classroom classroom);
    }
}
