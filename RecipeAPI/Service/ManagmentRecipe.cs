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
        public async Task NewRecipe(RecipeNewModel model)
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


        /// <summary>
        /// Удаление рецепта. Проставление признака активности
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteRecipe(int idDel)
        {
            var rec = connect.TblCatalogRecipes.Where(x => x.Id == idDel).FirstOrDefault();

            if (rec != null)
            {
                rec.Visible = false;
                connect.TblCatalogRecipes.Update(rec);

                await connect.SaveChangesAsync();
            }
        }
    }
}
