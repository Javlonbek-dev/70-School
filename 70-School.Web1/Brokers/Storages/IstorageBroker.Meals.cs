using _70_School.Web1.Models.Meals;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<Meal> InsertMealAsync(Meal meal);
        IQueryable<Meal> SelectAllMeals();
        ValueTask<Meal> SelectByIdMealAsync(Guid mealId);
    }
}
