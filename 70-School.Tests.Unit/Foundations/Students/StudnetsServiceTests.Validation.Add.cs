using _70_School.Web1.Models.Students;
using _70_School.Web1.Models.Students.Exceptions;
using FluentAssertions;
using Microsoft.Extensions.Hosting;
using Moq;
using Xunit;

namespace _70_School.Tests.Unit.Foundations.Students
{
    public partial class StudnetsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfInputIsNullAndLogItAsync()
        {
            //given
            Student nullStudent = null;
            var nullStudentException = new NullStudentException();

            var expectedStudentValidationException =
                new StudentValidationException(nullStudentException);

            //when
            ValueTask<Student> addStudentTask =
                this.studentService.AddStudentAsync(nullStudent);

            StudentValidationException actualStudentValidationException =
                await Assert.ThrowsAsync<StudentValidationException>(addStudentTask.AsTask);

            //then
            actualStudentValidationException.Should().BeEquivalentTo(expectedStudentValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedStudentValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(It.IsAny<Student>()), Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnAddIfStudentIsInvalidAndLogItAsync(string invalidString)
        {
            //given
            var invalidStudent = new Student
            {
                UserId = invalidString,
                IdentityNumber = invalidString,
                FirstName = invalidString
            };

            var invalidStudentException = new InvalidStudentException();

            invalidStudentException.AddData(
                key: nameof(Student.Id),
                values: "Id is required");

            invalidStudentException.AddData(
                key: nameof(Student.IdentityNumber),
                values: "Text is required");

            invalidStudentException.AddData(
                key: nameof(Student.UserId),
                values: "Text is required");

            invalidStudentException.AddData(
                key: nameof(Student.FirstName),
                values: "Text is required");

            invalidStudentException.AddData(
                key: nameof(Student.MiddleName),
                values: "Text is required");

            invalidStudentException.AddData(
                key: nameof(Student.LastName),
                values: "Text is required");

            invalidStudentException.AddData(
                key: nameof(Student.BirthDate),
                values: "Date is required");

            invalidStudentException.AddData(
                key: nameof(Student.CraeteDate),
                values: "Date is required");

            invalidStudentException.AddData(
                key: nameof(Student.UpdateDate),
                values: "Date is required");

            invalidStudentException.AddData(
                key: nameof(Student.CreatedBy),
                values: "Id is required");

            invalidStudentException.AddData(
                key: nameof(Student.UpdatedBy),
                values: "Id is required");

            var expectedStudentValidationException =
                new StudentValidationException(invalidStudentException);

            //when
            ValueTask<Student> addStudentTask = this.studentService.AddStudentAsync(invalidStudent);

            StudentValidationException actualStudentValidationException =
                await Assert.ThrowsAsync<StudentValidationException>(addStudentTask.AsTask);

            //then
            actualStudentValidationException.Should().BeEquivalentTo(expectedStudentValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedStudentValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(It.IsAny<Student>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfCreateAndUpdateDatesIsNotSameAndLogitAsync()
        {
            //given
            int randomNumber = CreateRandomNumber();
            Student randomStudent = CreateRandomStudent();
            Student invlidStudent = randomStudent;
            invlidStudent.UpdateDate = invlidStudent.CraeteDate.AddDays(randomNumber);
            var invalidStudentException = new InvalidStudentException();

            invalidStudentException.AddData(
                key: nameof(Student.UpdateDate),
                values: $"Date is not the same as {nameof(Student.CraeteDate)}");

            var expectedStudentValidationException = 
                new StudentValidationException(invalidStudentException);

            //when
            ValueTask<Student> addStudentTask= 
                this.studentService.AddStudentAsync(invlidStudent);

            StudentValidationException actualstudentValidationException =
                await Assert.ThrowsAsync<StudentValidationException>(addStudentTask.AsTask);

            //then
            actualstudentValidationException.Should().BeEquivalentTo(expectedStudentValidationException);

            this.loggingBrokerMock.Verify(broker=>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedStudentValidationException))),Times.Once);

            this.storageBrokerMock.Verify(broker=>
                broker.InsertStudentAsync(It.IsAny<Student>()), Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
