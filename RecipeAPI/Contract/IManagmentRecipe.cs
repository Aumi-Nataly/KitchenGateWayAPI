using RecipeAPI.Model;

namespace RecipeAPI.Contract
{
    /// <summary>
    /// Управление записями рецептов
    /// </summary>
    public interface IManagmentRecipe
    {
        /// <summary>
        /// Создание рецепта
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task NewRecipe(RecipeNewModel model);

        /// <summary>
        /// Удалить рецепт
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task DeleteRecipe(int idDel);
    }
}
