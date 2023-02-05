using _70_School.Web1.Models.Students;
using Microsoft.EntityFrameworkCore;

namespace _70_School.Web1.Brokers.Storages
{
    public partial class StorageBroker
    {
      public DbSet<Student> Students { get; set; }    
    }
}
