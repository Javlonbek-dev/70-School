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
        public void ShouldRetrieveAllStudents()
        {
            //given
            IQueryable<Student> randomStudent = CreateRandomStudents();
            IQueryable<Student> storageStudent = randomStudent;
            IQueryable<Student> expectedStudent = storageStudent;

            this.storageBrokerMock.Setup(broker=>
                broker.SelectAllStudents()).Returns(storageStudent);

            //when
            IQueryable<Student> actualStudent = this.studentService.RetrieveAllStudent();

            //then
            actualStudent.Should().BeEquivalentTo(expectedStudent);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllStudents(), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
