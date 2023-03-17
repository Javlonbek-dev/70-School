using _70_School.Web1.Models.Students;
using _70_School.Web1.Models.Students.Exceptions;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xeptions;

namespace _70_School.Web1.Services.Foundations.Students
{
    public partial class StudentService
    {
        private delegate ValueTask<Student> ReturningStudentFunction();
        private delegate IQueryable<Student> ReturningStudentsFunction();

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
            catch (InvalidStudentException invalidStudentException)
            {
                throw CreateAndLogValidationException(invalidStudentException);
            }
            catch (SqlException sqlException)
            {
                var failedStudentStorageException =
                    new FailedStudentStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedStudentStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExsitStudentException =
                    new AlreadyExsitStudentException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExsitStudentException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedStudentStorageException =
                    new FailedStudentStorageException(dbUpdateException);

                throw CreateAndLogDependecyException(failedStudentStorageException);
            }
            catch (Exception exception)
            {
                var failedStudentServiceException =
                    new FailedStudentServiceException(exception);

                throw CreateAndLogServiceException(failedStudentServiceException);
            }

        }

        private IQueryable<Student> TryCatch(ReturningStudentsFunction returningStudentFunctions)
        {
            try
            {
                return returningStudentFunctions();
            }
            catch (SqlException sqlException)
            {
                var failedStudentServiceException =
                    new FailedStudentServiceException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedStudentServiceException);
            }
            catch (Exception exception)
            {
                var failedStudentServiceException =
                    new FailedStudentServiceException(exception);

                throw CreateAndLogServiceException(failedStudentServiceException);
            }
        }

        private StudentServiceException CreateAndLogServiceException(Exception exception)
        {
            var studentServiceException = new StudentServiceException(exception);
            this.loggingBroker.LogError(studentServiceException);

            return studentServiceException;
        }

        private StudentDependencyException CreateAndLogDependecyException(Exception exception)
        {
            var studentDependencyException =
                 new StudentDependencyException(exception);

            this.loggingBroker.LogError(studentDependencyException);

            return studentDependencyException;
        }

        private StudentDependencyValidationException CreateAndLogDependencyValidationException(Xeption xeption)
        {
            var studentDependencyValidationException =
                new StudentDependencyValidationException(xeption);

            this.loggingBroker.LogError(studentDependencyValidationException);

            return studentDependencyValidationException;
        }

        private StudentDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
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
