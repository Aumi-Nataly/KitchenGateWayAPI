using System;
using System.Collections.Generic;

namespace RecipeAPI.RepDB.RecipeDB
{
    public partial class TblСomponent
    {
        public int Id { get; set; }
        public int RecId { get; set; }
        public string? ComponentName { get; set; }
        public string? Comment { get; set; }

        public virtual TblCatalogRecipe Rec { get; set; } = null!;
    }
}
