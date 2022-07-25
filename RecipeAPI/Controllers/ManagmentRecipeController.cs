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
        public ManagmentRecipeController(IManagmentRecipe managment)
        {
            _managment=managment;
        }

        /// <summary>
        /// Добавить новую запись рецепта
        /// </summary>
        /// <returns></returns>
         [HttpPost("NewRecipe")]
        public async Task<IActionResult> NewRecipe([FromBody] RecipeModel model)
        {
          await _managment.NewRecipe(model);

            return Ok();
        }
    }
}
