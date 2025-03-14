﻿using _70_School.Web1.Models.Students;
using _70_School.Web1.Models.Students.Exceptions;
using FluentAssertions;
using Moq;
using Xunit;

namespace _70_School.Tests.Unit.Foundations.Students
{
    public partial class StudnetsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnRetrieveByIdIfIdIsInvalidAndLogItAsync()
        {
            //given
            var invalidStudentId = Guid.Empty;
            var invalidStudentException = new InvalidStudentException();

            invalidStudentException.AddData(
                key: nameof(Student.Id),
                values: "Id is required");

            var expectedStudentValidationException =
                new StudentValidationException(invalidStudentException);

            //when
            ValueTask<Student> retrieveStudentByIdTask =
                this.studentService.RetrieveStudentByIdAsync(invalidStudentId);

            StudentValidationException actualStudentValidationException =
                await Assert.ThrowsAsync<StudentValidationException>(retrieveStudentByIdTask.AsTask);

            //then
            actualStudentValidationException.Should().BeEquivalentTo(
                expectedStudentValidationException);

            this.loggingBrokerMock.Verify(broker=>
                broker.LogError(It.Is(SameExceptionAs(expectedStudentValidationException))),Times.Once);

            this.storageBrokerMock.Verify(broker=>
                 broker.SelectStudentByIdAsync(It.IsAny<Guid>()),Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowNotFoundExceptionOnRetrieveByIdIfStudentIsNotFoundAndLogItAsync()
        {
            //given
            Guid someStudentId=Guid.NewGuid();
            Student? nullStudent = null;

            var notFoundStudentException =
                new NotFoundStudentException(someStudentId);

            var expectedStudentValidationException =
                new StudentValidationException(notFoundStudentException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectStudentByIdAsync(It.IsAny<Guid>()))
                    .ReturnsAsync(nullStudent);

            //when
            ValueTask<Student> retrieveStudentByIdTask=
                this.studentService.RetrieveStudentByIdAsync(someStudentId);

            StudentValidationException actualStudentValidationException =
                await Assert.ThrowsAsync<StudentValidationException>(retrieveStudentByIdTask.AsTask);

            //then
            actualStudentValidationException.Should().BeEquivalentTo(
                expectedStudentValidationException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectStudentByIdAsync(It.IsAny<Guid>()), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedStudentValidationException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
