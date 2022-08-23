using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Contract;
using RecipeAPI.Model;

namespace RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagmentRecipeController : Controller
    {
        public readonly IManagmentRecipe _managment;
        private readonly ILogger<ManagmentRecipeController> _logger;
        public ManagmentRecipeController(IManagmentRecipe managment, ILogger<ManagmentRecipeController> logger)
        {
            _managment = managment;
            _logger = logger;
        }

        /// <summary>
        /// Добавить новую запись рецепта
        /// </summary>
        /// <returns></returns>
        [HttpPost("NewRecipe")]
        public async Task<IActionResult> NewRecipe([FromBody] RecipeNewModel model)
        {
            try { 
            await _managment.NewRecipe(model);

            return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("контроллер ManagmentRecipeController метод AddorUpdateRecipe {numberError}", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Удаление(скрытие) рецепта
        /// </summary>
        /// <returns></returns>
        [HttpPost("DeleteRecipe")]
        public async Task<IActionResult> DeleteRecipe([FromBody] int idDel)
        {
            try
            {
                await _managment.DeleteRecipe(idDel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("контроллер ManagmentRecipeController метод AddorUpdateRecipe {numberError}", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Работа над составом рецепта
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddorUpdateRecipe")]
        public async Task<IActionResult> AddorUpdateRecipe([FromBody] RecipeNewModel model)
        {
            try
            {
                await _managment.AddorUpdateRecipe(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("контроллер ManagmentRecipeController метод AddorUpdateRecipe {numberError}", ex.Message);
                return null;
            }
        }
    }
}
