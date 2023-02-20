using _70_School.Web1.Models.Students;
using FluentAssertions;
using Force.DeepCloner;
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
        public async Task ShouldAddStudnetsAsync()
        {
            //given
            Student randomStudent = CreateRandomStudent();
            Student inputStudent = randomStudent;
            Student persistedStudent = inputStudent;
            Student expectedStudent = persistedStudent.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertStudentAsync(inputStudent)).ReturnsAsync(persistedStudent);

            //when
            Student actualStudent= await this.studentService.AddStudentAsync(inputStudent);

            //then
            actualStudent.Should().BeEquivalentTo(expectedStudent);

            this.storageBrokerMock.Verify(broker =>
              broker.InsertStudentAsync(inputStudent), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
