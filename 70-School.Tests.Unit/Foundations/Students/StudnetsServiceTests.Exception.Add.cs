using _70_School.Web1.Models.Students;
using _70_School.Web1.Models.Students.Exceptions;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _70_School.Tests.Unit.Foundations.Students
{
    public partial class StudnetsServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionOnAddIfSqlErrorOccursAndLogItAsync()
        {
            //given
            Student randomStudent= CreateRandomStudent();
            SqlException sqlException = GetSqlException();

            var failedStudentStorageException = 
                new FailedStudentStorageException(sqlException);

            StudentDependencyException expectedStudentDependencyException = 
                new StudentDependencyException(failedStudentStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertStudentAsync(randomStudent)).ThrowsAsync(sqlException);

            //when
             ValueTask<Student> addStudentTask= 
                this.studentService.AddStudentAsync(randomStudent);

            StudentDependencyException actualStudentDependencyException= 
                await Assert.ThrowsAsync<StudentDependencyException>(addStudentTask.AsTask);

            //then
            actualStudentDependencyException.Should().BeEquivalentTo(expectedStudentDependencyException);

            this.loggingBrokerMock.Verify(broker=>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedStudentDependencyException))),Times.Once);

            this.storageBrokerMock.Verify(broker=>
                broker.InsertStudentAsync(It.IsAny<Student>()),Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
