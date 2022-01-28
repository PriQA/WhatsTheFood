using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WhatsTheFoodService.Models;

namespace WhatsTheFoodService.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<FoodIngredient> FoodIngredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDislike> UserDislikes { get; set; }
        public DbSet<UserFoodPreference> userFoodPreferences { get; set; }
        public DbSet<FoodSource> FoodSources { get; set; }

        public new async Task<int> SaveChanges()
        {
            try
            {
                await base.SaveChangesAsync();
            }
            catch(Exception x)
            {


            }
            return 0;
            
        }
    }
}
