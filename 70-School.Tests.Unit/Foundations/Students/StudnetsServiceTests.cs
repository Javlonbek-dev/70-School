using _70_School.Web1.Brokers.DateTimes;
using _70_School.Web1.Brokers.Loggings;
using _70_School.Web1.Brokers.Storages;
using _70_School.Web1.Models.Students;
using _70_School.Web1.Services.Foundations.Students;
using Microsoft.Data.SqlClient;
using Moq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Tynamix.ObjectFiller;
using Xeptions;

namespace _70_School.Tests.Unit.Foundations.Students
{
    public partial class StudnetsServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly IStudentService studentService;

        public StudnetsServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();

            this.studentService = new StudentService(
                this.storageBrokerMock.Object,
                this.loggingBrokerMock.Object);
        }

        private static Student CreateRandomStudent() =>
            CreateStudentFiller().Create();

        private static int CreateRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();

        private static SqlException GetSqlException()=>
            (SqlException)FormatterServices.GetSafeUninitializedObject(typeof(SqlException));

        private static Expression<Func<Xeption,bool>> SameExceptionAs(Xeption expectedException)=>
            actualEception=>actualEception.SameExceptionAs(expectedException);

        private static Filler<Student> CreateStudentFiller()
        {
            var filler = new Filler<Student>();
            DateTimeOffset date = GetRandomDateTime();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
