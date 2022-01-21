using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WhatsTheFoodService.Models;

namespace WhatsTheFoodService.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<FoodCategory> FoodCategories { get; set; }
        DbSet<FoodIngredient> FoodIngredients { get; set; }
        DbSet<Food> Foods { get; set; }
        DbSet<FoodSource> FoodSources { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<UserDislike> UserDislikes { get; set; }
        DbSet<UserFoodPreference> userFoodPreferences { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChanges();
    }
}