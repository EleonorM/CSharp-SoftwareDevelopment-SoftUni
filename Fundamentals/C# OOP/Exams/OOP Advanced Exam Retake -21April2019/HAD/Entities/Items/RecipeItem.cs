namespace HAD.Entities.Items
{
    using HAD.Contracts;
    using System.Collections.Generic;

    public class RecipeItem : BaseItem, IRecipe
    {
        public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, List<string> requiredItems)
            : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
        {

            this.RequiredItems = requiredItems;
        }

        public IReadOnlyList<string> RequiredItems { get; private set; }
    }
}
