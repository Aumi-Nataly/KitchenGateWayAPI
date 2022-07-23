using System;
using System.Collections.Generic;

namespace RecipeAPI.RepDB.RecipeDB
{
    public partial class TblCatalogRecipe
    {
        public TblCatalogRecipe()
        {
            TblСomponents = new HashSet<TblСomponent>();
        }

        public int Id { get; set; }
        public string NameRecipe { get; set; } = null!;
        public int CatId { get; set; }
        public DateTime? DateAddRecipe { get; set; }
        public string? UserNameAdd { get; set; }

        public virtual TblCategory Cat { get; set; } = null!;
        public virtual ICollection<TblСomponent> TblСomponents { get; set; }
    }
}
