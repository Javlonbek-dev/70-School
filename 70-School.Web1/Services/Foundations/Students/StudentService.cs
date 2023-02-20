using _70_School.Web1.Brokers.Loggings;
using _70_School.Web1.Brokers.Storages;
using _70_School.Web1.Models.Students;
using System.Threading.Tasks;

namespace _70_School.Web1.Services.Foundations.Students
{
    public class StudentService:IStudentService
    {

        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public StudentService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Student> AddStudentAsync(Student student)=>
            await storageBroker.InsertStudentAsync(student);
    }
}
