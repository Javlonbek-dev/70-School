using System;

namespace _70_School.Web1.Models.Meals
{
    public class Meal
    {
        public Guid Id { get; set; }
        public MealType Type { get; set; }
        public double Price { get; set; }
        public Guid StudentId { get; set; }
        public MealStatus Status { get; set; }
        public int Quantity { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set;}
    }
}
