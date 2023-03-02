using _70_School.Web1.Models.Students;
using _70_School.Web1.Models.Students.Exceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;
using Xeptions;

namespace _70_School.Web1.Services.Foundations.Students
{
    public partial class StudentService
    {
        private delegate ValueTask<Student> ReturningStudentFunction();

        private async ValueTask<Student> TryCatch(ReturningStudentFunction returningStudentFunction)
        {
            try
            {
               return await returningStudentFunction();
            }
            catch (NullStudentException nullStudentException)
            {
                throw CreateAndLogValidationException(nullStudentException);
            }
            catch(InvalidStudentException invalidStudentException)
            {
                throw CreateAndLogValidationException(invalidStudentException);
            }
            catch(SqlException sqlException)
            {
                var failedStudentStorageException =
                    new FailedStudentStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedStudentStorageException);
            }
        }

        private StudentDependencyException CreateAndLogCriticalDependencyException(Xeption exception )
        {
            var studentDependencyException = 
                new StudentDependencyException(exception);

            this.loggingBroker.LogCritical(studentDependencyException);

            return studentDependencyException;
        }

        private StudentValidationException CreateAndLogValidationException(Xeption exception)
        {
            var studentValidationException = 
                new StudentValidationException(exception);

            this.loggingBroker.LogError(studentValidationException);

            return studentValidationException;
        }
    }
}
