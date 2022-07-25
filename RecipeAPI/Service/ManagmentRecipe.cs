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


        public async Task AddorUpdateRecipe(RecipeNewModel model)
        {
            var rec = connect.TblCatalogRecipes.Where(x => x.Id == model.Id).FirstOrDefault();

            if (rec != null)
            {
                foreach (var oneCom in model.Ingredients)
                {
                    var com = connect.TblСomponents.Where(x => x.Id == oneCom.Id).FirstOrDefault();

                    if (com != null)
                    {
                        com.ComponentName = oneCom.Name;
                        com.Comment = oneCom.Comment;

                        //запись отслеживается, то вызов Update не требуется.
                        //connect.TblСomponents.Update(component);

                    }
                    else
                    {
                        connect.TblСomponents.Add(
                            new TblСomponent
                            {
                                Id = oneCom.Id,
                                RecId = rec.Id,
                                ComponentName = oneCom.Name,
                                Comment = oneCom.Comment
                            });
                    }    

                }

                await connect.SaveChangesAsync();


            }
        }
    }
}
