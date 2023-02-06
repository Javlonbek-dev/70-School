using _70_School.Web1.Models.Classrooms;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<Classroom> InsertClassroom(Classroom classroom)=>
            await InsertAsync(classroom);
    }
}
