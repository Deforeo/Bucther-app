using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public interface IDishRepository : IRepository<Dish, Guid>
    {
        Task<IEnumerable<Dish>> GetDishesByCategoryAsync(Guid categoryId);
        Task<IEnumerable<Dish>> GetAvailableDishesAsync(); // не в стоп-листе и с остатками > 0
        Task<IEnumerable<DishCategory>> GetAllCategoriesAsync();
    }
}
