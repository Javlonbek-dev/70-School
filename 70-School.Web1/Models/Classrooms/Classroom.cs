using System;

namespace _70_School.Web1.Models.Classrooms
{
    public class Classroom
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ClassroomStatus Status { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set;}
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
    }
}
