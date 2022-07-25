﻿namespace RecipeAPI.Model
{
    /// <summary>
    /// Для создания нового рецепта
    /// </summary>
    public class RecipeModel
    {
        /// <summary>
        /// ID- рецепта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название рецепта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Кто создал запись
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Категория рецепта
        /// </summary>
        public int CatId { get; set; }

        /// <summary>
        /// Список ингредиентов
        /// </summary>
        public List<IngredientModel> Ingredients { get; set; }
    }
}
