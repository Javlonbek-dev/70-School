using _70_School.Web1.Models.Students;
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
        public async Task ShouldRetrieveStudentByIdAsync()
        {
            //given
            Guid randomStudentId= Guid.NewGuid();
            Guid inputStudentId = randomStudentId;
            Student randomStudent= CreateRandomStudent();
            Student storageStudent = randomStudent;
            Student expectedStudent= storageStudent;

            this.storageBrokerMock.Setup(broker=>
                broker.SelectStudentByIdAsync(inputStudentId))
                    .ReturnsAsync(storageStudent);

            //when
            Student actualStudent= 
                await this.studentService.RetrieveStudentByIdAsync(inputStudentId);

            //then
            actualStudent.Should().BeEquivalentTo(expectedStudent);

            this.storageBrokerMock.Verify(broker=>
                broker.SelectStudentByIdAsync(It.IsAny<Guid>()),Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
