using RecipeAPI.Contract;
using RecipeAPI.Model;
using RecipeAPI.RepDB.RecipeDB;

namespace RecipeAPI.Service
{
    public class ManagmentRecipe : IManagmentRecipe
    {
        private readonly RecipeDBContext connect;

        public ManagmentRecipe(RecipeDBContext connect)
        {
            this.connect = connect;
        }

        public Task NewRecipe(RecipeNewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
