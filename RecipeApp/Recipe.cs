// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using System;
using System.Collections;

namespace RecipeApp
{
    //Class for storing all recipe details
	public class Recipe
	{
        public string recipeName;
		public Ingredients[] ingredients;
		public Steps[] steps;

        //Ingredients[] and Steps[] taken as parameters in Recipe constructor
        //In order to group both arrays into one recipe object
		public Recipe(string recipeName, Ingredients[] ingredients, Steps[] steps)
		{
            this.recipeName = recipeName;
			this.ingredients = ingredients;
			this.steps = steps;
		}

        //method used to return recipe details as a string
		public string toString()
		{
            int recipeNum = 1;
            string output = "";
            
            int count = 1;
            output += "      -----ingredients-----\n";

            foreach (Ingredients ingredient in ingredients)
            {
                output += string.Format("{0}: {1}\n", count, ingredient.toString());
                count++;
            }

            output+=("\n      -----steps-----\n");
            count = 1;
            foreach (Steps step in steps) { 

                output += string.Format("{0}: {1}\n", count, step.toString());
                count++;
            }
            output += "\n";

            //System.out.println(count+": "+step.toString());
            return output;
            
        }
    }
}

