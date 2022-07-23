using System;
using System.Collections.Generic;

namespace RecipeAPI.RepDB.RecipeDB
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblCatalogRecipes = new HashSet<TblCatalogRecipe>();
        }

        public int Id { get; set; }
        public string? CatName { get; set; }

        public virtual ICollection<TblCatalogRecipe> TblCatalogRecipes { get; set; }
    }
}
