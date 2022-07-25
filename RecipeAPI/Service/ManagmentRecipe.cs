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

        /// <summary>
        /// Создание рецепта
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task NewRecipe(RecipeModel model)
        {
            //Вставка шапки 
            var rec = new TblCatalogRecipe
            {
                CatId = model.CatId,
                NameRecipe = model.Name,
                UserNameAdd = model.UserName
            };

            connect.TblCatalogRecipes.Add(rec);

            await connect.SaveChangesAsync();

            //  Вставка состава рецепта

            foreach (var oneCom in model.Ingredients)
            {
                var component = new TblСomponent
                {

                    RecId = rec.Id,
                    ComponentName = oneCom.Name,
                    Comment = oneCom.Comment
                };

                connect.TblСomponents.Add(component);
            }
            
            await connect.SaveChangesAsync();

          
        }
    }
}
