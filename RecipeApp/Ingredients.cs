using System;
namespace RecipeApp
{
	public class Ingredients
	{
		public string IngredientName { get; set; }
		public string UnitOfMeasure { get; set; }
		public double IngredientQty { get; set; }

		public Ingredients(string ingredientName, double ingredientQty, string unitOfMeasure)
		{
			IngredientName = ingredientName;
			UnitOfMeasure = unitOfMeasure;
			IngredientQty = ingredientQty;
		}
	}
}

