using System;
using System.Collections;

namespace RecipeApp
{

	public class Recipe
	{
		public Ingredients[] ingredients;
		public Steps[] steps;

		public Recipe(Ingredients[] ingredients, Steps[] steps)
		{
			this.ingredients = ingredients;
			this.steps = steps;
		}

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

