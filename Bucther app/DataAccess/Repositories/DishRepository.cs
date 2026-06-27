using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public class DishRepository : RepositoryBase<Dish, Guid>, IDishRepository
    {
        public DishRepository(DatabaseContext context) : base(context) { }

        protected override string GetByIdQuery => "sp_GetDishById";
        protected override string GetAllQuery => "sp_GetAllDishes";
        protected override string InsertQuery => "sp_InsertDish";
        protected override string UpdateQuery => "sp_UpdateDish";
        protected override string DeleteQuery => "sp_DeleteDish";

        public async Task<IEnumerable<Dish>> GetDishesByCategoryAsync(Guid categoryId)
        {
            var parameters = new { CategoryId = categoryId };
            return await _context.QueryAsync<Dish>("sp_GetDishesByCategory", parameters);
        }

        public async Task<IEnumerable<Dish>> GetAvailableDishesAsync()
        {
            return await _context.QueryAsync<Dish>("sp_GetAvailableDishes");
        }

        public async Task<IEnumerable<DishCategory>> GetAllCategoriesAsync()
        {
            return await _context.QueryAsync<DishCategory>("sp_GetAllCategories");
        }
    }
}
