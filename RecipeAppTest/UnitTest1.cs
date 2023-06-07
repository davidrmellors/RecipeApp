// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RecipeApp;
using System.Collections.Generic;

//Class to be tested
[TestClass]
public class UnitTest1
{

    //Method to be tested
    [TestMethod]
    public void testRecipeCalories()
    {
        //List to store ingredients
        List<Ingredients> ingredientsList = new List<Ingredients>();
        List<Steps> stepsList = new List<Steps>();

        //Ingredient objects to be added to list
        Ingredients ingredients1 = new Ingredients("Sugar", 1, "spoon", 200, "Starchy Foods");
        Ingredients ingredients2 = new Ingredients("Milk", 100, "ml", 2, "Milk and dairy products");
        Steps steps1 = new Steps("Add milk and sugar to bowl");

        ingredientsList.Add(ingredients1);
        ingredientsList.Add(ingredients2);
        stepsList.Add(steps1);

        Recipe recipe = new Recipe("Bread", ingredientsList, stepsList);

        //Use RecipeCalories() method to calculate recipe Calories
        double result = recipe.RecipeCalories(ingredientsList);

        //100 calories + 200 calories is 300 calories
        double expected = 300;

        //Assert.AreEqual used to test if expected result and result are equal
        Assert.AreEqual(expected, result);
    }
}
