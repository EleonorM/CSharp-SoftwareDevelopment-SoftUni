
using HAD.Entities.Items;
using HAD.Entities.Miscellaneous;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace HAD.Tests
{
    public class HeroInventoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShouldInitializeCollection()
        {
            var heroInventory = new HeroInventory();

            var expected = 0;
            Assert.AreEqual(expected, heroInventory.CommonItems.Count);
        }

        [Test]
        public void TotalStrengthBonus_ShouldSumCorrect()
        {
            var heroInventory = new HeroInventory();

            string name1 = "Test1";
            long strengthBonus1 = 100;
            long agilityBonus1 = 200;
            long intelligenceBonus1 = 250;
            long hitPointsBonus1 = 150;
            long damageBonus1 = 50;
            var commonItem1 = new CommonItem(name1, strengthBonus1, agilityBonus1, intelligenceBonus1, hitPointsBonus1, damageBonus1);

            string name2 = "Test2";
            long strengthBonus2 = 10;
            long agilityBonus2 = 20;
            long intelligenceBonus2 = 25;
            long hitPointsBonus2 = 15;
            long damageBonus2 = 5;
            var commonItem2 = new CommonItem(name2, strengthBonus2, agilityBonus2, intelligenceBonus2, hitPointsBonus2, damageBonus2);

            heroInventory.AddCommonItem(commonItem1);
            heroInventory.AddCommonItem(commonItem2);

            Assert.AreEqual(strengthBonus1+strengthBonus2, heroInventory.TotalStrengthBonus);
        }

        [Test]
        public void TotalAgilityBonus_ShouldSumCorrect()
        {
            var heroInventory = new HeroInventory();

            string name1 = "Test1";
            long strengthBonus1 = 100;
            long agilityBonus1 = 200;
            long intelligenceBonus1 = 250;
            long hitPointsBonus1 = 150;
            long damageBonus1 = 50;
            var commonItem1 = new CommonItem(name1, strengthBonus1, agilityBonus1, intelligenceBonus1, hitPointsBonus1, damageBonus1);

            string name2 = "Test2";
            long strengthBonus2 = 10;
            long agilityBonus2 = 20;
            long intelligenceBonus2 = 25;
            long hitPointsBonus2 = 15;
            long damageBonus2 = 5;
            var commonItem2 = new CommonItem(name2, strengthBonus2, agilityBonus2, intelligenceBonus2, hitPointsBonus2, damageBonus2);

            heroInventory.AddCommonItem(commonItem1);
            heroInventory.AddCommonItem(commonItem2);

            Assert.AreEqual(agilityBonus1 + agilityBonus2, heroInventory.TotalAgilityBonus);
        }

        [Test]
        public void TotalIntelligenceBonus_ShouldSumCorrect()
        {
            var heroInventory = new HeroInventory();

            string name1 = "Test1";
            long strengthBonus1 = 100;
            long agilityBonus1 = 200;
            long intelligenceBonus1 = 250;
            long hitPointsBonus1 = 150;
            long damageBonus1 = 50;
            var commonItem1 = new CommonItem(name1, strengthBonus1, agilityBonus1, intelligenceBonus1, hitPointsBonus1, damageBonus1);

            string name2 = "Test2";
            long strengthBonus2 = 10;
            long agilityBonus2 = 20;
            long intelligenceBonus2 = 25;
            long hitPointsBonus2 = 15;
            long damageBonus2 = 5;
            var commonItem2 = new CommonItem(name2, strengthBonus2, agilityBonus2, intelligenceBonus2, hitPointsBonus2, damageBonus2);

            heroInventory.AddCommonItem(commonItem1);
            heroInventory.AddCommonItem(commonItem2);

            Assert.AreEqual(intelligenceBonus1 + intelligenceBonus2, heroInventory.TotalIntelligenceBonus);
        }

        [Test]
        public void TotalHitPointsBonus_ShouldSumCorrect()
        {
            var heroInventory = new HeroInventory();

            string name1 = "Test1";
            long strengthBonus1 = 100;
            long agilityBonus1 = 200;
            long intelligenceBonus1 = 250;
            long hitPointsBonus1 = 150;
            long damageBonus1 = 50;
            var commonItem1 = new CommonItem(name1, strengthBonus1, agilityBonus1, intelligenceBonus1, hitPointsBonus1, damageBonus1);

            string name2 = "Test2";
            long strengthBonus2 = 10;
            long agilityBonus2 = 20;
            long intelligenceBonus2 = 25;
            long hitPointsBonus2 = 15;
            long damageBonus2 = 5;
            var commonItem2 = new CommonItem(name2, strengthBonus2, agilityBonus2, intelligenceBonus2, hitPointsBonus2, damageBonus2);

            heroInventory.AddCommonItem(commonItem1);
            heroInventory.AddCommonItem(commonItem2);

            Assert.AreEqual(hitPointsBonus1 + hitPointsBonus2, heroInventory.TotalHitPointsBonus);
        }

        [Test]
        public void TotalDamageBonus_ShouldSumCorrect()
        {
            var heroInventory = new HeroInventory();

            string name1 = "Test1";
            long strengthBonus1 = 100;
            long agilityBonus1 = 200;
            long intelligenceBonus1 = 250;
            long hitPointsBonus1 = 150;
            long damageBonus1 = 50;
            var commonItem1 = new CommonItem(name1, strengthBonus1, agilityBonus1, intelligenceBonus1, hitPointsBonus1, damageBonus1);

            string name2 = "Test2";
            long strengthBonus2 = 10;
            long agilityBonus2 = 20;
            long intelligenceBonus2 = 25;
            long hitPointsBonus2 = 15;
            long damageBonus2 = 5;
            var commonItem2 = new CommonItem(name2, strengthBonus2, agilityBonus2, intelligenceBonus2, hitPointsBonus2, damageBonus2);

            heroInventory.AddCommonItem(commonItem1);
            heroInventory.AddCommonItem(commonItem2);

            Assert.AreEqual(damageBonus1 + damageBonus2, heroInventory.TotalDamageBonus);
        }

        [Test]
        public void AddCommonItem_ShouldAddItemCorrectly()
        {
            var heroInventory = new HeroInventory();

            string name1 = "Test1";
            long strengthBonus1 = 100;
            long agilityBonus1 = 200;
            long intelligenceBonus1 = 250;
            long hitPointsBonus1 = 150;
            long damageBonus1 = 50;
            var commonItem1 = new CommonItem(name1, strengthBonus1, agilityBonus1, intelligenceBonus1, hitPointsBonus1, damageBonus1);

            heroInventory.AddCommonItem(commonItem1);

            Assert.That(heroInventory.CommonItems.Contains(commonItem1));
        }

        [Test]
        public void AddRecipe_ShouldCheckRecipeFor0ExistingCommonItemsAsRequested()
        {
            var heroInventory = new HeroInventory();

            string name1 = "Test1";
            long strengthBonus1 = 100;
            long agilityBonus1 = 200;
            long intelligenceBonus1 = 250;
            long hitPointsBonus1 = 150;
            long damageBonus1 = 50;
            List<string> requiredItems = new List<string>{ "one","two"};
            var commonItem1 = new RecipeItem(name1, strengthBonus1, agilityBonus1, intelligenceBonus1, hitPointsBonus1, damageBonus1,requiredItems);

            heroInventory.AddRecipeItem(commonItem1);

            Assert.That(heroInventory.CommonItems.Count == 0);
        }

        [Test]
        public void AddRecipe_ShouldCheckRecipeForSomeExistingCommonItemsAsRequested()
        {
            var heroInventory = new HeroInventory();

            string name1 = "TestRecipe";
            long strengthBonus1 = 100;
            long agilityBonus1 = 200;
            long intelligenceBonus1 = 250;
            long hitPointsBonus1 = 150;
            long damageBonus1 = 50;
            List<string> requiredItems = new List<string> { "Test1", "two" };
            var commonItem1 = new RecipeItem(name1, strengthBonus1, agilityBonus1, intelligenceBonus1, hitPointsBonus1, damageBonus1, requiredItems);


            string nameItem = "Test1";
            long strengthBonusItem = 100;
            long agilityBonusItem = 200;
            long intelligenceBonusItem = 250;
            long hitPointsBonusItem = 150;
            long damageBonusItem = 50;
            var commonItemItem = new CommonItem(nameItem, strengthBonusItem, agilityBonusItem, intelligenceBonusItem, hitPointsBonusItem, damageBonusItem);

            heroInventory.AddCommonItem(commonItem1);

            heroInventory.AddRecipeItem(commonItem1);

            Assert.That(heroInventory.CommonItems.Count == 1);
        }

        [Test]
        public void AddRecipe_ShouldCheckRecipeForAllExistingCommonItemsAsRequested()
        {
            var heroInventory = new HeroInventory();

            string name1 = "TestRecipe";
            long strengthBonus1 = 100;
            long agilityBonus1 = 200;
            long intelligenceBonus1 = 250;
            long hitPointsBonus1 = 150;
            long damageBonus1 = 50;
            List<string> requiredItems = new List<string> { "Test1","Test2"};
            var recipe = new RecipeItem(name1, strengthBonus1, agilityBonus1, intelligenceBonus1, hitPointsBonus1, damageBonus1, requiredItems);


            string nameItem = "Test1";
            long strengthBonusItem = 100;
            long agilityBonusItem = 200;
            long intelligenceBonusItem = 250;
            long hitPointsBonusItem = 150;
            long damageBonusItem = 50;
            var commonItem1 = new CommonItem(nameItem, strengthBonusItem, agilityBonusItem, intelligenceBonusItem, hitPointsBonusItem, damageBonusItem);

            string name2 = "Test2";
            long strengthBonus2 = 10;
            long agilityBonus2 = 20;
            long intelligenceBonus2 = 25;
            long hitPointsBonus2 = 15;
            long damageBonus2 = 5;
            var commonItem2 = new CommonItem(name2, strengthBonus2, agilityBonus2, intelligenceBonus2, hitPointsBonus2, damageBonus2);

            heroInventory.AddCommonItem(commonItem1);
            heroInventory.AddCommonItem(commonItem2);

            heroInventory.AddRecipeItem(recipe);

            Assert.That(heroInventory.CommonItems.Count == 1);
            Assert.That(heroInventory.CommonItems.FirstOrDefault(x=>x.Name == name1) != null);
        }
    }
}