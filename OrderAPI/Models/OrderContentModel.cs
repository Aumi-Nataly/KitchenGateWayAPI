namespace OrderAPI.Models
{
    public class OrderContentModel
    {
        /// <summary>
        /// код контента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название рецепта
        /// </summary>
        public string NameRecipe { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public float Price { get; set; }
    }
}
