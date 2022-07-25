namespace RecipeAPI.Model
{
    /// <summary>
    /// Создание нового рецепта
    /// </summary>
    public class RecipeNewModel: RecipeModel
    {
        /// <summary>
        /// Список ингредиентов
        /// </summary>
        public List<IngredientModel> Ingredients { get; set; }

       
    }
}
