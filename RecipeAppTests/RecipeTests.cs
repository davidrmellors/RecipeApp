using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Tests
{
    [TestClass()]
    public class RecipeTests
    {
        [TestMethod()]
        public void RecipeCaloriesTest()
        {
            Assert.Fail();
            var ingredient1 = new Mock<Ingredients>();
            ingredient1.SetupGet(i => i.IngredientCalories).Returns(500);

            var ingredient2 = new Mock<Ingredients>();
            ingredient2.SetupGet(i => i.IngredientCalories).Returns(750);

            List<Ingredients> testIngredients = new List<Ingredients>();
            testIngredients.Add(ingredient1.Object);
            testIngredients.Add(ingredient2.Object);

            var recipe = new Recipe("Recipe Name", testIngredients, new List<Steps>());

            double expectedResult = 1250;
            double actualResult = recipe.RecipeCalories();

            Assert.Equal(expectedResult, actualResult);
        }
    }
}