﻿using _70_School.Web1.Models.Students.Exceptions;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;

namespace _70_School.Tests.Unit.Foundations.Students
{
    public partial class StudnetsServiceTests
    {
        [Fact]
        public void ShouldThrowCriticalDependencyExceptionOnRetrieveAllWhenSqlExceptionOccursAndLogIt()
        {
            //given
            SqlException sqlException = CreateRandomException();

            var failedStudentServiceException =
                new FailedStudentServiceException(sqlException);

            var expectedStudentDependencyException =
                new StudentDependencyException(failedStudentServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllStudents()).Throws(sqlException);

            //when
            Action retrieveAllStudentAction = () =>
                studentService.RetrieveAllStudent();

            StudentDependencyException actualStudentDependencyException =
                Assert.Throws<StudentDependencyException>(retrieveAllStudentAction);

            //then
            actualStudentDependencyException.Should().BeEquivalentTo(
                expectedStudentDependencyException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllStudents(), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedStudentDependencyException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnRetrieveAllIfServiceErrorOccursAndLogItAsync()
        {
            //given
            string expectedMessage = GetRandomMessage();
            var serviceException = new Exception(expectedMessage);

            var failedStudentServiceException =
                new FailedStudentServiceException(serviceException);

            var expectedStudentServiceException =
                new StudentServiceException(failedStudentServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllStudents()).Throws(serviceException);

            //when
            Action retrieveAllStudentAction = () =>
                studentService.RetrieveAllStudent();

            StudentServiceException actualStudentServiceException =
                Assert.Throws<StudentServiceException>(retrieveAllStudentAction);

            //then
            actualStudentServiceException.Should().BeEquivalentTo(
                expectedStudentServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllStudents(), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedStudentServiceException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
