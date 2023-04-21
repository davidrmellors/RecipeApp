using System;
using System.Collections;

namespace RecipeApp
{
	public class InputHandler
	{
		public InputHandler()
		{
		}

		public void UserInput()
		{
            Console.WriteLine("----------Recipe App----------");

            //INGREDIENTS

			Console.WriteLine("     -----Ingredients-----");

			Console.Write("\nPlease enter the number of ingredients for your recipe: ");
			int numOfIngredients = ValidateInt(Console.ReadLine());

			Ingredients[] ingredients = new Ingredients[numOfIngredients];

            
			for(int i = 0; i < numOfIngredients; i++)
			{
                Console.Write("\nPlease enter the details of your {0}{1} ingredient following " +
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

            Console.WriteLine("     -----Steps-----");

            Console.Write("Please enter the number of steps your recipe requires: ");
            int numOfSteps = ValidateInt(Console.ReadLine());

            Steps[] steps = new Steps[numOfSteps];

            for(int i = 0; i < numOfSteps; i++)
            {
                Console.Write("Please enter step {0}: ", (i + 1));
                string step = NotNull(Console.ReadLine());
                steps[i] = new Steps(step);
            }

            List<Recipe> recipes = new List<Recipe>();

            recipes.Add(new Recipe(ingredients, steps));

            Recipe recipe = new Recipe();

            recipe.PrintRecipe(recipes);
		}

		public int ValidateInt(string num)
		{
			int c;
			while(int.TryParse(num, out c) == false)
			{
				Console.WriteLine("Please enter an integer: ");
				num = Console.ReadLine();
			}
			Console.WriteLine("Captured value: {0}", c);
			return c;
		}

        public double ValidateDouble(string num)
        {
            double c;
            while (double.TryParse(num, out c) == false)
            {
                Console.WriteLine("Please enter a value of type double: ");
                num = Console.ReadLine();
            }
            Console.WriteLine("Captured value: {0}", c);
            return c;
        }

        public string GetNumberSuffix(int number)
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

        public string NotNull(string input)
        {
            while (string.IsNullOrEmpty(input))
            {
                Console.Write("Please enter a string: ");
                input = Console.ReadLine();
            }
            Console.WriteLine("Captured value : {0}", input);
            return input;
        }
    }
}

