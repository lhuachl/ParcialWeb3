using PrimerParcial.Data;
using PrimerParcial.Models;
using Microsoft.EntityFrameworkCore;

namespace PrimerParcial.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task SeedDataAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<RecetasDBContext>();

            // Apply any pending migrations
            await context.Database.MigrateAsync();

            // Check if we already have data
            if (await context.Categories.AnyAsync())
                return;

            // Seed Categories
            var categories = new[]
            {
                new Category { Name = "Postres", Description = "Dulces y postres deliciosos" },
                new Category { Name = "Platos Principales", Description = "Comidas principales para almuerzo y cena" },
                new Category { Name = "Aperitivos", Description = "Botanas y aperitivos para compartir" },
                new Category { Name = "Bebidas", Description = "Bebidas refrescantes y calientes" },
                new Category { Name = "Ensaladas", Description = "Ensaladas frescas y saludables" }
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();

            // Seed Sample Recipes
            var recipes = new[]
            {
                new Recipe 
                { 
                    Name = "Chocolate Chip Cookies", 
                    Description = "Deliciosas galletas con chispas de chocolate",
                    Instructions = "1. Precalienta el horno a 375°F. 2. Mezcla todos los ingredientes secos. 3. Agrega mantequilla y huevos. 4. Incorpora las chispas de chocolate. 5. Hornea por 10-12 minutos.",
                    DifficultyLevel = 3,
                    PreparationTime = 30,
                    CategoryId = 1, // Postres
                    CreatedDate = DateTime.Now
                },
                new Recipe 
                { 
                    Name = "Pasta Carbonara", 
                    Description = "Pasta italiana clásica con huevos y panceta",
                    Instructions = "1. Cocina la pasta al dente. 2. Fríe la panceta hasta que esté crujiente. 3. Mezcla huevos con queso parmesano. 4. Combina todo fuera del fuego. 5. Sirve inmediatamente.",
                    DifficultyLevel = 5,
                    PreparationTime = 25,
                    CategoryId = 2, // Platos Principales
                    CreatedDate = DateTime.Now
                },
                new Recipe 
                { 
                    Name = "Ensalada César", 
                    Description = "Ensalada fresca con aderezo césar casero",
                    Instructions = "1. Lava y corta la lechuga romana. 2. Prepara crutones tostados. 3. Mezcla ingredientes del aderezo. 4. Combina todo y sirve con queso parmesano.",
                    DifficultyLevel = 2,
                    PreparationTime = 15,
                    CategoryId = 5, // Ensaladas
                    CreatedDate = DateTime.Now
                }
            };

            context.Recipes.AddRange(recipes);
            await context.SaveChangesAsync();

            // Seed Sample Ingredients
            var ingredients = new[]
            {
                // Ingredients for Chocolate Chip Cookies
                new Ingredient { Name = "Harina de trigo", Quantity = "2 tazas", RecipeId = 1 },
                new Ingredient { Name = "Mantequilla", Quantity = "1 taza", RecipeId = 1 },
                new Ingredient { Name = "Azúcar morena", Quantity = "3/4 taza", RecipeId = 1 },
                new Ingredient { Name = "Chispas de chocolate", Quantity = "1 taza", RecipeId = 1 },
                new Ingredient { Name = "Huevos", Quantity = "2 piezas", RecipeId = 1 },

                // Ingredients for Pasta Carbonara
                new Ingredient { Name = "Pasta espagueti", Quantity = "400 gramos", RecipeId = 2 },
                new Ingredient { Name = "Panceta", Quantity = "150 gramos", RecipeId = 2 },
                new Ingredient { Name = "Huevos", Quantity = "3 piezas", RecipeId = 2 },
                new Ingredient { Name = "Queso parmesano", Quantity = "100 gramos", RecipeId = 2 },
                new Ingredient { Name = "Pimienta negra", Quantity = "al gusto", RecipeId = 2 },

                // Ingredients for Caesar Salad
                new Ingredient { Name = "Lechuga romana", Quantity = "2 cabezas", RecipeId = 3 },
                new Ingredient { Name = "Pan para crutones", Quantity = "4 rebanadas", RecipeId = 3 },
                new Ingredient { Name = "Queso parmesano", Quantity = "50 gramos", RecipeId = 3 },
                new Ingredient { Name = "Mayonesa", Quantity = "3 cucharadas", RecipeId = 3 },
                new Ingredient { Name = "Jugo de limón", Quantity = "2 cucharadas", RecipeId = 3 }
            };

            context.Ingredients.AddRange(ingredients);
            await context.SaveChangesAsync();
        }
    }
}