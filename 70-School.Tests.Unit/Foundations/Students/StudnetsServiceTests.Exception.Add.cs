using _70_School.Web1.Models.Students;
using _70_School.Web1.Models.Students.Exceptions;
using EFxceptions.Models.Exceptions;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace _70_School.Tests.Unit.Foundations.Students
{
    public partial class StudnetsServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionOnAddIfSqlErrorOccursAndLogItAsync()
        {
            //given
            Student randomStudent = CreateRandomStudent();
            SqlException sqlException = GetSqlException();

            var failedStudentStorageException =
                new FailedStudentStorageException(sqlException);

            StudentDependencyException expectedStudentDependencyException =
                new StudentDependencyException(failedStudentStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertStudentAsync(randomStudent)).ThrowsAsync(sqlException);

            //when
            ValueTask<Student> addStudentTask =
               this.studentService.AddStudentAsync(randomStudent);

            StudentDependencyException actualStudentDependencyException =
                await Assert.ThrowsAsync<StudentDependencyException>(addStudentTask.AsTask);

            //then
            actualStudentDependencyException.Should().BeEquivalentTo(expectedStudentDependencyException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedStudentDependencyException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(It.IsAny<Student>()), Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAddIfStudentAlreadyExistsAndLogItAsync()
        {
            //given
            var someStudent= CreateRandomStudent();
            string randomMesssage = GetRandomMessage();
            var duplicateKeyException = new DuplicateKeyException(randomMesssage);

            var alreadyExsitStudentException =
                new AlreadyExsitStudentException(duplicateKeyException);

            StudentDependencyValidationException expectedStudentDependencyValidationException = 
                new StudentDependencyValidationException(alreadyExsitStudentException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertStudentAsync(It.IsAny<Student>()))
                    .ThrowsAsync(duplicateKeyException);

            //when
            ValueTask<Student> addStudentTask =
                this.studentService.AddStudentAsync(someStudent);

            StudentDependencyValidationException actualStudentDependencyValidationException =
                await Assert.ThrowsAsync<StudentDependencyValidationException>(addStudentTask.AsTask);

            //then
            actualStudentDependencyValidationException.Should().BeEquivalentTo(
                expectedStudentDependencyValidationException);

            this.storageBrokerMock.Verify(broker=>
                broker.InsertStudentAsync(It.IsAny<Student>()),Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedStudentDependencyValidationException))), Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async  Task ShouldThrowDependencyExceptionOnAddIfDatabaseUpdateErrorOccursAndLogItAsync()
        {
            //given
            var someStudent = CreateRandomStudent();
            var databaseUpdateException = new DbUpdateException();

            var failedStudentStorageException = 
                new FailedStudentStorageException(databaseUpdateException);

            var expectedStudentDependencyException =
                new StudentDependencyException(failedStudentStorageException);

            this.storageBrokerMock.Setup(broker=>
                broker.InsertStudentAsync(It.IsAny<Student>())).ThrowsAsync(databaseUpdateException);

            //when
            ValueTask<Student> addStudentTask = this.studentService.AddStudentAsync(someStudent);

            StudentDependencyException actualStudentDependencyException =
                await Assert.ThrowsAsync<StudentDependencyException>(addStudentTask.AsTask);

            //then
            actualStudentDependencyException.Should().BeEquivalentTo(expectedStudentDependencyException);

            this.storageBrokerMock.Verify(broker=>
                broker.InsertStudentAsync(It.IsAny<Student>()),Times.Once);

            this.loggingBrokerMock.Verify(broker=>
                broker.LogError(It.Is(SameExceptionAs(expectedStudentDependencyException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAddIfDatabaseUpdateErrorOccursAndLogItAsync()
        {
            //given
            var someStudent = CreateRandomStudent();
            var serviceException = new Exception();

            var failedStudentServiceException = 
                new FailedStudentServiceException(serviceException);

            var expectedStudentServiceException = new StudentServiceException(serviceException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertStudentAsync(It.IsAny<Student>()))
                    .ThrowsAsync(serviceException);

            //when
            ValueTask<Student> addStudentTask = this.studentService.AddStudentAsync(someStudent);
            
            StudentServiceException actualStudentServiceException= 
                await Assert.ThrowsAsync<StudentServiceException>(addStudentTask.AsTask);

            //then
            actualStudentServiceException.Should().BeEquivalentTo(expectedStudentServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(It.IsAny<Student>()), Times.Once);

            this.loggingBrokerMock.Verify(broker=>
                broker.LogError(It.Is(SameExceptionAs(expectedStudentServiceException))),Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
