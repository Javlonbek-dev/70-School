using _70_School.Web1.Brokers.Loggings;
using _70_School.Web1.Brokers.Storages;
using _70_School.Web1.Models.Students;
using System.Linq;
using System.Threading.Tasks;

namespace _70_School.Web1.Services.Foundations.Students
{
    public partial class StudentService:IStudentService
    {

        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public StudentService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Student> AddStudentAsync(Student student) =>
            TryCatch(async () =>
            {
                ValidateUser(student);

                return await this.storageBroker.InsertStudentAsync(student);
            });

        public IQueryable<Student> RetrieveAllStudent()=>
           TryCatch(()=>this.storageBroker.SelectAllStudents());
    }
}
