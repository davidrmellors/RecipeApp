using System;
using System.Collections;
namespace RecipeApp
{
	public class Recipe
	{
		Ingredients[] ingredients;
		Steps[] steps;

		public Recipe(Ingredients[] ingredients, Steps[] steps)
		{
			this.ingredients = ingredients;
			this.steps = steps;
		}

		public Recipe()
		{

		}

		public void PrintRecipe(List<Recipe> recipes)
		{

			foreach(Recipe recipe in recipes)
			{
                int count = 1;
                foreach (Ingredients ingredient in recipe.ingredients)
				{
					Console.WriteLine("Ingredient {0}: {1} {2} of {3}", count, ingredient.IngredientQty, ingredient.UnitOfMeasure, ingredient.IngredientName);
                    count++;
                }

				count = 1;
				foreach(Steps step in recipe.steps)
				{
					Console.WriteLine("Step {0}: {1}", count, step.Step);
                    count++;
                }

			}
		}

	}
}

