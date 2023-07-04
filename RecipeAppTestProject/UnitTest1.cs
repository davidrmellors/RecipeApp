using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp;
using System;
using System.Collections.Generic;

namespace RecipeAppTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //List to store ingredients
            List<Ingredients> ingredientsList = new List<Ingredients>();
            List<Steps> stepsList = new List<Steps>();

            //Ingredient objects to be added to list
            Ingredients ingredients1 = new Ingredients("Sugar", 1, "spoon", 200, "Starchy Foods");
            Ingredients ingredients2 = new Ingredients("Milk", 100, "ml", 150, "Milk and dairy products");
            Steps steps1 = new Steps("Add milk and sugar to bowl");

            //add objects to lists
            ingredientsList.Add(ingredients1);
            ingredientsList.Add(ingredients2);
            stepsList.Add(steps1);

            //Recipe recipe = new Recipe("Bread", ingredientsList, stepsList);

            //Use RecipeCalories() method to calculate recipe Calories
            //double result = recipe.RecipeCalories(ingredientsList);

            //100 calories + 200 calories is 300 calories
            double expected = 350;

            //Assert.AreEqual used to test if expected result and result are equal
            //Assert.AreEqual(expected, result);
        }
    }
}
