using _70_School.Web1.Models.Students;
using _70_School.Web1.Models.Students.Exceptions;
using System;

namespace _70_School.Web1.Services.Foundations.Students
{
    public partial class StudentService
    {

        private static void ValidateUser(Student student)
        {
            ValidateStudentNotNull(student);

            Validate(
                (Rule: IsInvalid(student.Id), Parameter: nameof(Student.Id)),
                (Rule: IsInvalid(student.IdentityNumber), Parameter: nameof(Student.IdentityNumber)),
                (Rule: IsInvalid(student.UserId), Parameter: nameof(Student.UserId)),
                (Rule: IsInvalid(student.FirstName), Parameter: nameof(Student.FirstName)),
                (Rule: IsInvalid(student.MiddleName), Parameter: nameof(Student.MiddleName)),
                (Rule: IsInvalid(student.LastName), Parameter: nameof(Student.LastName)),
                (Rule: IsInvalid(student.BirthDate), Parameter: nameof(Student.BirthDate)),
                (Rule: IsInvalid(student.CraeteDate), Parameter: nameof(Student.CraeteDate)),
                (Rule: IsInvalid(student.UpdateDate), Parameter: nameof(Student.UpdateDate)),
                (Rule: IsInvalid(student.CreatedBy), Parameter: nameof(Student.CreatedBy)),
                (Rule: IsInvalid(student.UpdatedBy), Parameter: nameof(Student.UpdatedBy)),

                (Rule: IsNotSame(firstDate: student.UpdateDate,
                    secondDate: student.CraeteDate,
                    secondDateName: nameof(Student.CraeteDate)),
                Parameter: nameof(Student.UpdateDate))
                );
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string Text) => new
        {
            Condition = string.IsNullOrWhiteSpace(Text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static dynamic IsNotSame(
            DateTimeOffset firstDate,
            DateTimeOffset secondDate,
            string secondDateName) => new
            {
                Condition = firstDate != secondDate,
                Message = $"Date is not the same as {secondDateName}"
            };

        private static void ValidateStudentNotNull(Student student)
        {
            if (student is null)
            {
                throw new NullStudentException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidStudentException = new InvalidStudentException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidStudentException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidStudentException.ThrowIfContainsErrors();
        }
    }
}
