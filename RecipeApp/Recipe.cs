// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RecipeApp
{
    //Class for storing all recipe details
    public class Recipe
    {
        public string recipeName;
        public ObservableCollection<Ingredients> ingredientsList = new ObservableCollection<Ingredients>();
        public ObservableCollection<Steps> stepsList = new ObservableCollection<Steps>();

        //Ingredients[] and Steps[] taken as parameters in Recipe constructor
        //In order to group both arrays into one recipe object
        public Recipe(string recipeName, ObservableCollection<Ingredients> ingredientsList, ObservableCollection<Steps> stepsList)
        {
            this.recipeName = recipeName;
            this.ingredientsList = ingredientsList;
            this.stepsList = stepsList;
        }

        //Calculate total calories within a recipe
        public double RecipeCalories(List<Ingredients> ingredientsList)
        {
            double totalCalories = 0;
            foreach (Ingredients ingredients in ingredientsList)
            {
                totalCalories += ingredients.IngredientCalories;
            }

            return totalCalories;
        }

        //method used to return recipe details as a string
        public string toString()
        {
            int recipeNum = 1;
            string output = "";

            int count = 1;

            output += string.Format("Total Calories for recipe: {0}\n", RecipeCalories(ingredientsList));

            double dailyIntakePercent;

            dailyIntakePercent = (RecipeCalories(ingredientsList) / 2000) * 100;

            output += string.Format("This is {0}% of your daily recommended caloric intake\n", dailyIntakePercent);

            RecipeCalories(ingredientsList);

            foreach (Ingredients ingredient in ingredientsList)
            {
                output += string.Format("\n[{0}{1} Ingredient]" +
                    "\n{2}\n\n", count, InputHandler.GetNumberSuffix(count), ingredient.toString());
                count++;
            }

            output+=("[Steps]\n");
            count = 1;
            foreach (Steps step in stepsList)
            {

                output += string.Format("{0}: {1}\n", count, step.toString());
                count++;
            }

            return output;
        }
    }
}
