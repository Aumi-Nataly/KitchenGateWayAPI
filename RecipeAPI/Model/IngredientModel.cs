namespace RecipeAPI.Model
{
    /// <summary>
    /// Состав рецепта
    /// </summary>
    public class IngredientModel
    {
        /// <summary>
        /// ID- ингредиента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование продукта
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }
    }
}
