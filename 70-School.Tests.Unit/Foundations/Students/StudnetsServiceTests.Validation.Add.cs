using _70_School.Web1.Models.Students;
using _70_School.Web1.Models.Students.Exceptions;
using FluentAssertions;
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
        public async Task ShouldThrowValidationExceptionOnAddIfInputIsNullAndLogItAsync()
        {
            //given
            Student nullStudent = null;
            var nullStudentException= new NullStudentException();

            var expectedStudentValidationException = 
                new StudentValidationException(nullStudentException);

            //when
            ValueTask<Student> addStudentTask = 
                this.studentService.AddStudentAsync(nullStudent);

            StudentValidationException actualStudentValidationException = 
                await Assert.ThrowsAsync<StudentValidationException>(addStudentTask.AsTask);

            //then
            actualStudentValidationException.Should().BeEquivalentTo(expectedStudentValidationException);

            this.loggingBrokerMock.Verify(broker=>
                broker.LogError(It.Is(SameExceptionAs(expectedStudentValidationException))),Times.Once);
            
            this.storageBrokerMock.Verify(broker=>
                broker.InsertStudentAsync(It.IsAny<Student>()),Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
