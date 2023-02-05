using _70_School.Web1.Models.Students;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Student> Students { get; set; }

        public async ValueTask<Student> InsertStudentAsync(Student student) =>
            await InsertAsync(student);

        public async ValueTask<Student> SelectStudentByIdAsync(Guid Id) =>
            await SelectAsync<Student>(Id);
    }
}
