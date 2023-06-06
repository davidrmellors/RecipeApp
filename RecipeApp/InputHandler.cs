// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using System;
using System.Collections;
using System.Xml.Linq;
using System.Xml.Schema;
using Microsoft.VisualBasic.FileIO;

namespace RecipeApp
{
    //Class used to handle all user input
	public class InputHandler
	{
        public InputHandler()
		{
		}

        delegate void CaloriesChecker(int totalCalories);

        //define the method to output warning message when total calories exceed 300
        static void WarnExceedCalories(int totalCalories)
        {
            if (totalCalories > 300)
            {
                Console.WriteLine("\nThe total calories of this recipe exceeds 300!");
            }
        }


        //Method used to request user input and gather required recipe data
        public void UserInput()
		{
            //integer variable used to condition while loop
            //loop will break only when the user enters the number 6
            int option = 0;

            while (option != 6)
            {
                //Clears the console window to de-clutter console output
                Console.Clear();
                Console.WriteLine("-----------------");
                Console.WriteLine("   Recipe App  ");
                Console.WriteLine("-----------------\n");

                //Menu used to display all features of Recipe App
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add new recipe");
                Console.WriteLine("2. List recipes");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset recipe");
                Console.WriteLine("5. Clear recipe");
                Console.WriteLine("6. Exit");

                //Store user's input in option to analyze which menu option they
                //choose
                int input = InputHandler.ValidateInt();
                //switch statement which calls the relevent method responsible
                //for the funtionality of the menu option the user chooses

                switch(input)
                {
                    case 1:
                        AddRecipe();
                        break;
                    case 2:
                        RecipeList.ListRecipes();
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
                    case 6:
                        option = 6;
                        break;
                    default:
                        break;
                }
            } 
		}

        //Method used to instantiate relevent ingredient and step details
        //by using user input and then storing the details in their relevent
        //class, using objects
        public static void AddRecipe()
        {
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("     Recipe  ");
            Console.WriteLine("-----------------");

            string recipeName;
            bool correct = false;

            do
            {
                Console.Write("\nPlease enter the name of your recipe >> ");
                recipeName = NotNull(Console.ReadLine());

                Console.Write("Is your recipe name correct?\nType [yes] or [no]: ");
                if (Console.ReadLine().Equals("yes"))
                    correct = true;

            } while (correct == false);




            //Clears the console window to de-clutter console output
            Console.Clear();

            //Ingredients section
            Console.WriteLine("----------------------");
            Console.WriteLine("Ingredients for {0}  ", recipeName);
            Console.WriteLine("----------------------");
            
            //verify user input is an int using ValidateInt() method and then storing
            //the verified value in numOfIngredients varaible

            int numOfIngredients = 0;
            bool isValid = false;
            while (!isValid)
            {
                //Ask user to enter the number of ingredients for their recipe
                Console.Write("\nPlease enter the number of ingredients your recipe requires, as an integer: ");
                try
                {
                    numOfIngredients = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input: " + e.Message);
                }
            }



            //Create new Array of type Ingredients with the length of numOfIngredients
            /*Ingredients[] ingredients = new Ingredients[numOfIngredients];*/

            List <Ingredients> ingredientsList = new List<Ingredients>();

            int totalCalories = 0;

            //instantiate the delegate with the defined method
            CaloriesChecker caloriesChecker = WarnExceedCalories;

            //for loop used to instantiate each position of the array with
            //ingredient quantity, ingredient unit of measure and ingredient name
            for (int i = 0; i < numOfIngredients; i++)
            {
                //bool variable used to condition the do while loop
                correct = false;
                //strings used to store the name and unitOfMeasure of each ingredient
                string ingredientName, unitOfMeasure, ingredientFoodGroup;
                //dobule used to store the Quantity of each ingredient
                double ingredientQty;
                int ingredientCalories = 0;

                //do while that loops until the user is happy with their input
                do
                {
                    //Clears the console window to de-clutter console output
                    Console.Clear();
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Ingredients for {0}  ", recipeName);
                    Console.WriteLine("----------------------\n");

                    //Outputted at first line of the console window to show user what section they are in
                    Console.WriteLine("Please enter the details of your {0}{1} ingredient following " +
                        "\nthis format: [quantity] [unit of measure] [ingredient name] " +
                        "\nfor example: 1 cup milk", (i + 1), GetNumberSuffix(i + 1));

                    ingredientQty = 0;
                    isValid = false;
                    while (!isValid)
                    {
                        Console.Write("\nPlease enter the quantity of your ingredient as an integer >> ");
                        try
                        {
                            ingredientQty = double.Parse(Console.ReadLine());
                            isValid = true;
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Invalid input: " + e.Message);
                        }
                    }
                    
                    //validate user input is a double using ValidateDouble() method
                    //and storing it in ingredientQty variable.

                    Console.Write("\nPlease enter the unit of measurement of your ingredient >> ");
                    //validate user input is not empty using NotNull() method
                    //and storing the returned value in unitOfMeasure variable
                    unitOfMeasure = (NotNull(Console.ReadLine()));

                    Console.Write("Please enter the name of your ingredient >> ");
                    //validate user input is not empty using NotNull() method
                    //and then store the returned value in ingredientName variable
                    ingredientName = (NotNull(Console.ReadLine()));

                    isValid = false;
                    while (!isValid)
                    {
                        Console.Write("\nPlease enter the total number of calories" +
                            "\nfor your ingredient as an integer >> ");
                        try
                        {
                            ingredientCalories = int.Parse(Console.ReadLine());
                            isValid = true;
                            // Keep track of total calories
                            totalCalories += ingredientCalories;
                            caloriesChecker(totalCalories); // invoke delegate to check if calories exceed 300 and output warning message if necessary
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Invalid input: " + e.Message);
                        }
                    }


                    Console.Write("\nPlease enter the name of the food group" +
                        "\nthis ingredient belongs to >> ");
                    ingredientFoodGroup = (NotNull(Console.ReadLine()));


                    //Clears the console window to de-clutter console output
                    Console.Clear();
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Ingredients for {0}  ", recipeName);
                    Console.WriteLine("----------------------");

                    //Outputs the details of the nth ingredient
                    Console.WriteLine("\n[{0}{1} Ingredient]" +
                        "\nquantity: {2}" +
                        "\nunit of measurement: {3} " +
                        "\nname: {4}" +
                        "\ntotal calories: {5}" +
                        "\nfood group: {6}", (i + 1), GetNumberSuffix(i + 1), ingredientQty, unitOfMeasure,
                        ingredientName, ingredientCalories, ingredientFoodGroup);

                    //Asks user if the ingredient details they entered for the nth ingredient is accurate
                    Console.Write("\nIs your {0}{1} ingredient correct?" +
                        "\nType [yes] or [no] >> ", (i + 1), GetNumberSuffix(i + 1));

                    //if the user types yes the loop will break
                    if (Console.ReadLine().Equals("yes"))
                        correct = true;

                } while(correct == false);

                //add the object of type Ingredients with the user entered details
                ingredientsList.Add(new Ingredients(ingredientName, ingredientQty, unitOfMeasure, ingredientCalories, ingredientFoodGroup));
            }
            //Clears the console window to de-clutter console output
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("  Steps for {0}  ", recipeName);
            Console.WriteLine("----------------------");

            //Ask user to enter number of steps

            int numOfSteps = 0;
            isValid = false;
            while (!isValid)
            {
                Console.Write("\nPlease enter the number of steps your recipe requires: ");
                try
                {
                    numOfSteps = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input: " + e.Message);
                }
            }
            
            //Validate user input using ValidateInt() method and store in numOfSteps variable

            //Create new array of type Steps of size numOfSteps
            /*Steps[] steps = new Steps[numOfSteps];*/
            List<Steps> stepsList = new List<Steps>();

            //Loop used to instantiate each index of the array with a new object of type Steps
            //This object takes the string step variable which holds a new step for the recipe
            //entered by the user
            for (int i = 0; i < numOfSteps; i++)
            {
                correct = false;
                string step;
                do
                {
                    //Clears the console window to de-clutter console output
                    Console.Clear();
                    //Outputted at first line of the console window to show user what section they are in
                    Console.WriteLine("----------------------");
                    Console.WriteLine("  Steps for {0}  ", recipeName);
                    Console.WriteLine("----------------------\n");

                    Console.Write("Please enter step {0}: ", (i + 1));
                    //User input is required to not be empty using the NotNull() method
                    step = NotNull(Console.ReadLine());

                    //Clears the console window to de-clutter console output
                    Console.Clear();
                    //Outputted at first line of the console window to show user what section they are in
                    Console.WriteLine("----------------------");
                    Console.WriteLine("  Steps for {0}  ", recipeName);
                    Console.WriteLine("----------------------\n");

                    Console.WriteLine("Step {0}: {1}", (i + 1), step);
                    Console.Write("\nIs your {0}{1} step accurate?\nType [yes] or [no]: ", (i + 1), GetNumberSuffix(i + 1));

                    if (Console.ReadLine().Equals("yes"))
                        correct = true;

                } while (correct == false);
                
                stepsList.Add(new Steps(step));
            }
            //After all ingredients and steps have been entered the ingredients array and
            //steps array are parsed to the Recipes class using the object of the recipe class
            //named recipe
            Recipe recipe = new Recipe(recipeName, ingredientsList, stepsList);

            //the Recipe object recipe is then parsed to the RecipeList class using the object
            //of the RecipeList class named recipeList
            RecipeList recipeList = new RecipeList(recipe);
        }

        //Takes a string num as parameter and trys to convert num to int
        //if the conversion fails it means the user has not entered an int
        //the user is then asked to re-enter an int until the conversion is
        //successful. The user entered int is then returned
        public static int ValidateInt()
		{
            int num = 0;
            bool isValid = false;
            while (!isValid)
            {
                Console.Write(">> ");
                try
                {
                    num = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input.\nPlease enter the integer associated with your option of choice.");
                }
            }
            return num;
        }

        //Takes a string num as parameter and trys to convert num to double
        //if the conversion fails it means the user has not entered a double
        //the user is then asked to re-enter a double until the conversion is
        //successful. The user entered double is then returned
        public static double ValidateDouble(string num)
        {
            double c;
            while (double.TryParse(num, out c) == false)
            {
                Console.Write("Please enter a value of type double: ");
                num = Console.ReadLine();
            }
            Console.WriteLine("Captured value: {0}\n", c);
            return c;
        }


        //takes an integer input number and returns a string representing
        //the suffix for that number (e.g. "st" for 1, "nd" for 2, "rd" for 3,
        //and "th" for all other numbers).
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

        //Takes string input as parameter and checks wheter it is Null or Empty
        //if string input is empty or null the user will be asked to re-enter a string
        //until the input is not Null or Empty. The string input is then returned.
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
       /* private static void ClearConsole()
        {
            Console.SetCursorPosition(0, 4);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 4);
        }*/
    }
}

