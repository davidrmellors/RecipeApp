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

        //Ingredient objects to be added to list
        Ingredients ingredients1 = new Ingredients("Sugar", 1, "spoon", 200, "Starchy Foods");
        Ingredients ingredients2 = new Ingredients("Milk", 100, "ml", 2, "Milk and dairy products");

        ingredientsList.Add(ingredients1);
        ingredientsList.Add(ingredients2);

        //double used to store total calories
        double totalCalories = 0;

        //foreach used to add calories of all ingredients within ingredientsList
        foreach (Ingredients ingredients in ingredientsList)
        {
            totalCalories += ingredients.IngredientCalories;
        }

        //100 calories + 200 calories is 300 calories
        double expected = 300;
        double result = totalCalories;

        //Assert.AreEqual used to test if expected result and result are equal
        Assert.AreEqual(expected, result);
    }
}
