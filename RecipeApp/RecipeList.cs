
using System;
namespace RecipeApp
{
	public class RecipeList
	{
		static List<Recipe> recipeList = new List<Recipe>();
		public RecipeList(Recipe recipe)
		{
            recipeList.Add(recipe);
		}

        public static void PrintRecipe()
        {
            int recipeNum = 1;
            foreach (Recipe recipe in recipeList)
            {
                Console.WriteLine("\n----------[ {0}{1} Recipe ]----------", recipeNum, InputHandler.GetNumberSuffix(recipeNum));
                Console.WriteLine(recipe.toString());
                recipeNum++;
            }
            Console.WriteLine("Press any key to continue");    
        }

        public static void ScaleRecipe()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Scale recipe by 0.5");
            Console.WriteLine("2. Scale recipe by 2");
            Console.WriteLine("3. Scale recipe by 3");

            int input = InputHandler.ValidateInt(Console.ReadLine());

            while(input > 3 || input < 1){
                Console.Write("Menu option does not exist\nPlease try again >> ");
                input = InputHandler.ValidateInt(Console.ReadLine());
            }

            if (input.Equals(1))
            {
                Recipe recipe = (Recipe)recipeList[0];
                foreach(Ingredients ingedients in recipe.ingredients)
                {
                    ingedients.Scale(0.5);
                }
            }
            else if (input.Equals(2)){
                Recipe recipe = (Recipe)recipeList[0];
                foreach (Ingredients ingedients in recipe.ingredients)
                {
                    ingedients.Scale(2);
                }
            }
            else if (input.Equals(3))
            {
                Recipe recipe = (Recipe)recipeList[0];
                foreach (Ingredients ingedients in recipe.ingredients)
                {
                    ingedients.Scale(3);
                }
            }
        }

        public static void ResetRecipe()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Reset quantities to original values");
            Console.WriteLine("2. Exit");
            Console.Write(">> ");

            int input = InputHandler.ValidateInt(Console.ReadLine());

            while (input > 2 || input < 1)
            {
                Console.Write("Menu option does not exist\nPlease try again >> ");
                input = InputHandler.ValidateInt(Console.ReadLine());
            }

            if(input!= 2)
            {
                if (input.Equals(1))
                {
                    Recipe recipe = (Recipe)recipeList[0];
                    foreach (Ingredients ingredients in recipe.ingredients)
                    {
                        ingredients.IngredientQty = ingredients.IngredientQtyOriginal;
                    }
                }
            }
            
        }

        public static void ClearRecipe()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Clear all data");
            Console.WriteLine("2. Exit");
            Console.Write(">> ");

            int input = InputHandler.ValidateInt(Console.ReadLine());

            while (input > 2 || input < 1)
            {
                Console.Write("Menu option does not exist\nPlease try again >> ");
                input = InputHandler.ValidateInt(Console.ReadLine());
            }

            if(input != 2)
            {
                Console.WriteLine("Are you sure you want to clear all data?");
                Console.Write("Type [yes] or [no] >> ");

                string confirm = InputHandler.NotNull(Console.ReadLine());

                if (confirm.Equals("yes"))
                {
                    recipeList.Clear();
                }
            }
        }

    }
}

