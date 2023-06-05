// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using System;
namespace RecipeApp
{
	public class RecipeList
	{
        static List<Recipe> recipeList = new List<Recipe>();


        //Array of type Recipe used to store 
        //static Recipe[] recipeList = new Recipe[1];
        //Constructor takes object of Recipe class and stores in recipeList array
		public RecipeList(Recipe recipe)
		{
            recipeList.Add(recipe);
		}

        public static void PrintRecipe()
        {
            //Clears the console window to de-clutter console output
            Console.Clear();

            //If recipeList is not empty then display the recipe details
            if (!recipeList.Contains(default(Recipe)))
            {
                Console.WriteLine("-----Here are your Recipes-----");


                recipeList.Sort();
                //used to indicate the recipe number
                int recipeNum = 1;

                //for each object of type recipe in the recipeList array, call the recipe.toString() method that returns
                //all recipe details
                foreach (Recipe recipe in recipeList)
                {
                    Console.WriteLine("\n----------[ {0} ]----------\n", recipe.recipeName, InputHandler.GetNumberSuffix(recipeNum));
                    Console.WriteLine(recipe.toString());
                }
                Console.WriteLine("---------------------------------------------");
            }else
            {
                //if no recipes have been captured output this message to console
                Console.WriteLine("No Recipes have been captured!");
            }
            Console.Write("\nPress and key to continue >> ");
            Console.ReadLine();
        }

        //Method used to ask user by which value they want to scale their recipe quantity by
        //value then used when caling the Scale method from Ingredients class
        public static void ScaleRecipe()
        {
            //Clears the console window to de-clutter console output
            Console.Clear();

            //If recipeList is not empty then display the recipe details
            if (!recipeList.Contains(default(Recipe)))
            {
                Console.WriteLine("      -----Scale Recipe-----");

                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Scale recipe by 0.5");
                Console.WriteLine("2. Scale recipe by 2");
                Console.WriteLine("3. Scale recipe by 3");
                Console.WriteLine("4. Exit");
                Console.Write(">> ");

                int input = InputHandler.ValidateInt(Console.ReadLine());
                double scale = 1;

                //Requires user to enter a valid menu option
                while(input > 3 || input < 1){
                    Console.Write("Menu option does not exist\nPlease try again >> ");
                    input = InputHandler.ValidateInt(Console.ReadLine());
                }

                if (input != 4)
                {
                    switch (input)
                    {
                        case 1:
                            scale = 0.5;
                            break;
                        case 2:
                            scale = 2;
                            break;
                        case 3:
                            scale = 3;
                            break;
                    }

                    //unbox object of Type recipe in recipeList array and store it in new object recipe
                    Recipe recipe = (Recipe)recipeList[0];

                    //For each ingredient in the recipe call Scale() method to scale the quantity
                    foreach (Ingredients ingedients in recipe.ingredients)
                    {
                        ingedients.Scale(scale);
                    }
                }
            }
            else
            {
                //if no recipes have been captured output this message to console
                Console.WriteLine("No Recipes have been captured!");
            }
            Console.Write("\nPress and key to continue >> ");
            Console.ReadLine();
        }

        //Takes original quantities of ingredients and replaces the new quantity
        public static void ResetRecipe()
        {
            //Clears the console window to de-clutter console output
            Console.Clear();
            Console.WriteLine("      -----Reset Recipe-----");

            //If recipeList is not empty then display the recipe details
            if (!recipeList.Contains(default(Recipe)))
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Reset quantities to original values");
                Console.WriteLine("2. Exit");
                Console.Write(">> ");

                int input = InputHandler.ValidateInt(Console.ReadLine());

                //Requires user to enter a valid menu option
                while (input > 2 || input < 1)
                {
                    Console.Write("Menu option does not exist\nPlease try again >> ");
                    input = InputHandler.ValidateInt(Console.ReadLine());
                }

                //as long as the user does not select option 2 from the menu
                //the ingredient quantities will be reset
                if (input != 2)
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
            else
            {
                //if no recipes have been captured output this message to console
                Console.WriteLine("No Recipes have been captured!");
            }
            Console.Write("\nPress and key to continue >> ");
            Console.ReadLine();
        }

        //Method used to empty the recipeList array
        public static void ClearRecipe()
        {
            //Clears the console window to de-clutter console output
            Console.Clear();
            Console.WriteLine("      -----Reset Recipe-----");

            if (!recipeList.Contains(default(Recipe)))
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

                //as long as the user does not select option 2 from the menu
                //the ingredient quantities will be reset
                if (input != 2)
                {
                    Console.WriteLine("Are you sure you want to clear all data?");
                    Console.Write("Type [yes] or [no] >> ");

                    string confirm = InputHandler.NotNull(Console.ReadLine());
                    //if user confirms that they want to clear all data then
                    //the recipeList will be cleared to default(Recipe)
                    if (confirm.Equals("yes"))
                    {
                        recipeList[0] = default(Recipe);
                    }
                }
            }
            else
            {
                //if no recipes have been captured output this message to console
                Console.WriteLine("No Recipes have been captured!");
            }
            Console.Write("\nPress and key to continue >> ");
            Console.ReadLine();
        }

    }
}

