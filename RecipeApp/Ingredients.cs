// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using System;
namespace RecipeApp
{
	public class Ingredients
	{
		public string IngredientName { get; set; }
		public string UnitOfMeasure { get; set; }
		public double IngredientQty { get; set; }
		public double IngredientQtyOriginal;
		public double IngredientCalories {  get; set; }
        public double IngredientCaloriesOriginal;
        public string IngredientFoodGroup { get; set; }
		

		//Ingredient details taken as parameters in constructor and stored locally.
		public Ingredients(string ingredientName, double ingredientQty, string unitOfMeasure, 
			int ingredientCalories, string ingredientFoodGroup)
		{
			IngredientName = ingredientName;
			UnitOfMeasure = unitOfMeasure;
			IngredientQty = ingredientQty;
			IngredientCalories = ingredientCalories;
			IngredientFoodGroup = ingredientFoodGroup;
		}

		//method used to return ingredient details as string
		public string toString()
		{
			/*string output = string.Format("{0} {1} of {2}", IngredientQty, UnitOfMeasure, IngredientName);*/
            string output = string.Format("quantity: {0}" +
                        "\nunit of measurement: {1} " +
                        "\nname: {2}" +
                        "\ntotal calories: {3}" +
                        "\nfood group: {4}", IngredientQty, UnitOfMeasure,
                        IngredientName, IngredientCalories, IngredientFoodGroup);
            return output;
        }

		//method that takes scale value as parameter and multiplies local
		//ingredient quantitiy by scale value "factor"
		public void Scale(double factor)
		{
			//original ingredient quantity stored in IngredientQtyOriginal variable
			//used for Reset method
			IngredientQtyOriginal = IngredientQty;
			IngredientCaloriesOriginal = IngredientCalories;
			IngredientQty *= factor;
			IngredientCalories *= factor;
			
		}

		public void ResetRecipe()
		{
			IngredientQty = IngredientQtyOriginal;
			IngredientCalories = IngredientCaloriesOriginal;
		}
	}
}

