using System;

namespace _70_School.Web1.Models.Course
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseStatus Status { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
    }
}
