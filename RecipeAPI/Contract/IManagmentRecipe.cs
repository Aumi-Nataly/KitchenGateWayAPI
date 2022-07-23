using RecipeAPI.Model;

namespace RecipeAPI.Contract
{
    /// <summary>
    /// Управление записями рецептов
    /// </summary>
    public interface IManagmentRecipe
    {
        public Task NewRecipe(RecipeNewModel model);
    }
}
