using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.RepDB.RecipeDB;
using RecipeAPI.Service;

namespace RecipeApi.Test
{
    public class UnitTest_Recipe
    {
        [Fact]
        public void DeleteRecipe_Test()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<RecipeDBContext>().UseSqlite(connection).Options;

            using (var context = new RecipeDBContext(options))
            {
                context.Database.EnsureCreated();
                context.TblCategories.Add(new TblCategory {Id=1,CatName="Cat1" });
                context.TblCatalogRecipes.AddRange(
                    new TblCatalogRecipe { Id=1, NameRecipe="Name1", CatId=1, Visible=true , DateAddRecipe=DateTime.Now},
                    new TblCatalogRecipe { Id = 2, NameRecipe = "Name2", CatId = 1, Visible = true, DateAddRecipe = DateTime.Now },
                    new TblCatalogRecipe { Id = 3, NameRecipe = "Name3", CatId = 1, Visible = true , DateAddRecipe = DateTime.Now }
                    );
                context.SaveChanges();
            }

            using (var context = new RecipeDBContext(options))
            {
                var service = new ManagmentRecipe(context);
                var catalog = service.DeleteRecipe(2);

                Assert.NotNull(catalog);
                Assert.Equal(3, context.TblCatalogRecipes.Count());
            }

            connection.Close();
        }
    }
}