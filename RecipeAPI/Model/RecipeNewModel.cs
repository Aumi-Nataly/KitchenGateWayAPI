namespace RecipeAPI.Model
{
    /// <summary>
    /// Для создания нового рецепта
    /// </summary>
    public class RecipeNewModel
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public int CatId { get; set; }

        List<IngredientModel> Ingredients { get; set; }
    }
}
