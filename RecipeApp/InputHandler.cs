using System;
using System.Collections;

namespace RecipeApp
{
	public class InputHandler
	{

        public static List<Recipe> recipes = new List<Recipe>();
        public InputHandler()
		{
		}

		public void UserInput()
		{
            int option = 0;

            while (option != 6)
            {
                Console.WriteLine("----------[Recipe App]----------");

                //MENU
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add new recipe");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset recipe");
                Console.WriteLine("5. Clear recipe");
                Console.WriteLine("6. Exit");
                Console.Write(">> ");

                option = ValidateInt(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddRecipe();
                        break;
                    case 2:
                        RecipeList.PrintRecipe();
                        break;
                    case 3:
                        RecipeList.ScaleRecipe();
                        break;
                    case 4:
                        RecipeList.ResetRecipe();
                        break;
                    case 5:
                        RecipeList.ClearRecipe();
                        break;
                    default:
                        break;
                }
            } 
		}

        public static void AddRecipe()
        {
            //INGREDIENTS
            Console.WriteLine("\n      -----ingredients-----");

            Console.Write("\nPlease enter the number of ingredients for your recipe: ");
            int numOfIngredients = ValidateInt(Console.ReadLine());

            Ingredients[] ingredients = new Ingredients[numOfIngredients];


            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.WriteLine("\nPlease enter the details of your {0}{1} ingredient following " +
                        "\nthis format: [quantity] [unit of measure] [ingredient name] " +
                        "\nfor example: 1 cup milk", (i + 1), GetNumberSuffix(i + 1));

                Console.Write("\nQuantity: ");
                double ingredientQty = ValidateDouble(Console.ReadLine());

                Console.Write("\nUnit of measurement: ");
                string unitOfMeasure = (NotNull(Console.ReadLine()));

                Console.Write("\nName of ingredient: ");
                string ingredientName = (NotNull(Console.ReadLine()));

                ingredients[i] = new Ingredients(ingredientName, ingredientQty, unitOfMeasure);
            }

            //STEPS
            Console.WriteLine("\n      -----steps-----");

            Console.Write("Please enter the number of steps your recipe requires: ");
            int numOfSteps = ValidateInt(Console.ReadLine());

            Steps[] steps = new Steps[numOfSteps];

            for (int i = 0; i < numOfSteps; i++)
            {
                Console.Write("\nPlease enter step {0}: ", (i + 1));
                string step = NotNull(Console.ReadLine());
                steps[i] = new Steps(step);
            }
            Recipe recipe = new Recipe(ingredients, steps);

            RecipeList recipeList = new RecipeList(recipe);
        }



        public static int ValidateInt(string num)
		{
			int c;
			while(int.TryParse(num, out c) == false)
			{
				Console.WriteLine("Please enter an integer: ");
				num = Console.ReadLine();
			}
			Console.WriteLine("Captured value: {0}\n", c);
			return c;
		}

        public static double ValidateDouble(string num)
        {
            double c;
            while (double.TryParse(num, out c) == false)
            {
                Console.WriteLine("Please enter a value of type double: ");
                num = Console.ReadLine();
            }
            Console.WriteLine("Captured value: {0}\n", c);
            return c;
        }

        public static string GetNumberSuffix(int number)
        {
            int lastDigit = number % 10;
            int lastTwoDigits = number % 100;

            if (lastTwoDigits >= 11 && lastTwoDigits <= 13)
            {
                return "th";
            }

            switch (lastDigit)
            {
                case 1:
                    return "st";
                case 2:
                    return "nd";
                case 3:
                    return "rd";
                default:
                    return "th";
            }
        }

        public static string NotNull(string input)
        {
            while (string.IsNullOrEmpty(input))
            {
                Console.Write("Please enter a string: ");
                input = Console.ReadLine();
            }
            Console.WriteLine("Captured value : {0}\n", input);
            return input;
        }
    }
}

