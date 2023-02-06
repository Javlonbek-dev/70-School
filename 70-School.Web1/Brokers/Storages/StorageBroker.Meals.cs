using _70_School.Web1.Models.Meals;
using System.Linq;
using System.Threading.Tasks;

namespace _70_School.Web1.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<Meal> InsertMealAsync(Meal meal) =>
            await InsertAsync(meal);

        public IQueryable<Meal> SelectAllMeals() =>
            SelectAll<Meal>();
    }
}
