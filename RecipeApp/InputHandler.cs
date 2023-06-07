// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Schema;

namespace RecipeApp
{
    //Class used to handle all user input
    public class InputHandler
    {
        public InputHandler()
        {
        }

        delegate void CaloriesChecker(int totalCalories);

        //method to output warning message when total calories exceed 300
        static void WarnExceedCalories(int totalCalories)
        {
            if (totalCalories > 300)
            {
                // set console text colour to red
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe total calories of this recipe exceeds 300!");

                //calculate percentage of daily calorie intake

                double dailyIntakePercent;

                dailyIntakePercent = (totalCalories / 2000) * 100;

                //output of daily caloric intake to user
                Console.WriteLine("This is {0}% of your daily recommended caloric intake", dailyIntakePercent);
                Console.WriteLine();
                Console.ResetColor();
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
                #region Menu
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

                //Try Catch used to validate that the user is entering an integer
                //and is a valid menu option
                int input = 0;
                bool isValid = false;
                while (!isValid)
                {
                    Console.Write(">> ");
                    try
                    {
                        input = int.Parse(Console.ReadLine());
                        if (input > 0 && input < 7)
                        {
                            isValid = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input." +

                            "\nThe menu option you entered does not exist.");
                            Console.ResetColor();
                        }

                    }
                    catch (FormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input." +
                            "\nPlease enter the integer associated with your option of choice.");
                        Console.ResetColor();
                    }
                }

                //switch statement which calls the relevent method responsible
                //for the funtionality of the menu option the user chooses
                switch (input)
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
            #endregion
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

            // confirmation of users recipe name
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

            #region Ingredients
            //Ingredients section
            Console.WriteLine("----------------------");
            Console.WriteLine("Ingredients for {0}  ", recipeName); //uses recipes name as heading
            Console.WriteLine("----------------------");

            //Try Catch used to validate that the user is entering an integer
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input: " + e.Message);
                    Console.ResetColor();

                }
            }



            //Create new List of type Ingredients with the length of numOfIngredients
            List<Ingredients> ingredientsList = new List<Ingredients>();

            //int used to keep track of totalCalories
            int totalCalories = 0;

            //instantiate the delegate with the defined method
            CaloriesChecker caloriesChecker = WarnExceedCalories;

            //for loop used to instantiate each position of the List with
            //ingredient quantity, ingredient unit of measure, ingredient name
            //ingredientFoodGroup and ingredientCalories
            for (int i = 0; i < numOfIngredients; i++)
            {
                //bool variable used to condition the do while loop
                correct = false;
                //strings used to store the name, unitOfMeasure and food group of each ingredient
                string ingredientName, unitOfMeasure, ingredientFoodGroup = "";
                //double used to store the Quantity of each ingredient
                double ingredientQty;
                //int used to store the total calories for each ingredient
                int ingredientCalories = 0;

                //do while that loops until the user is happy with their input
                do
                {
                    //Clears the console window to de-clutter console output
                    Console.Clear();
                    //Outputted at first line of the console window to show user what section they are in
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Ingredients for {0}  ", recipeName);
                    Console.WriteLine("----------------------\n");

                    //Show user the format intended for input
                    Console.WriteLine("Please enter the details of your {0}{1} ingredient following " +
                        "\nthis format: [quantity] [unit of measure] [ingredient name] " +
                        "\nfor example: 1 cup milk", (i + 1), GetNumberSuffix(i + 1));

                    //Try Catch used to validate that the user is entering an integer 
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input: " + e.Message);
                            Console.ResetColor();
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

                    //Explanation of calories to user
                    Console.WriteLine("The amount of energy in food or drink is measured in calories");

                    //Try Catch used to validate that the user is entering an integer
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input: " + e.Message);
                            Console.ResetColor();
                        }
                    }

                    //Explanation of what a food group is to user
                    Console.WriteLine("\nA food group is a collection of foods " +
                        "\nthat share similar nutritional properties or biological classifications.");

                    //Menu used for user to choose a food group their ingredient belongs to
                    Console.WriteLine("\nChoose a food group for your ingredient:");
                    Console.WriteLine("1. Starchy Foods");
                    Console.WriteLine("2. Vegetables and Fruits");
                    Console.WriteLine("3. Dry beans, peas, lentils and soya");
                    Console.WriteLine("4. Chicken, fish, meat and eggs");
                    Console.WriteLine("5. Milk and dairy products");
                    Console.WriteLine("6. Fats and oil");
                    Console.WriteLine("7. Water");

                    //Try Catch used to validate that the user is entering an integer
                    // and a valid menu option
                    int option = 0;
                    isValid = false;
                    while (!isValid)
                    {
                        Console.Write(">> ");
                        try
                        {
                            option = int.Parse(Console.ReadLine());
                            if (option > 0 && option < 8)
                            {
                                isValid = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input." +
                                "\nThe menu option you entered does not exist.");
                                Console.ResetColor();
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input." +
                                "\nPlease enter the integer associated with your option of choice.");
                            Console.ResetColor();
                        }
                    }

                    // switch statement that assigns desired food group to ingredient
                    switch (option)
                    {
                        case 1:
                            ingredientFoodGroup = "Starchy Foods";
                            break;
                        case 2:
                            ingredientFoodGroup = "Vegetables and Fruits";
                            break;
                        case 3:
                            ingredientFoodGroup = "Dry beans, peas, lentils and soya";
                            break;
                        case 4:
                            ingredientFoodGroup = "Chicken, fish, meat and eggs";
                            break;
                        case 5:
                            ingredientFoodGroup = "Milk and dairy products";
                            break;
                        case 6:
                            ingredientFoodGroup = "Fats and oils";
                            break;
                        case 7:
                            ingredientFoodGroup = "Water";
                            break;
                        default:
                            break;
                    }


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

                } while (correct == false);

                //add the object of type Ingredients with the user entered details
                ingredientsList.Add(new Ingredients(ingredientName, ingredientQty, unitOfMeasure, ingredientCalories, ingredientFoodGroup));
                #endregion Ingredients
            }
            //Clears the console window to de-clutter console output
            Console.Clear();
            #region Steps
            //Steps Section
            Console.WriteLine("----------------------");
            Console.WriteLine("  Steps for {0}  ", recipeName);
            Console.WriteLine("----------------------");

            //Ask user to enter number of steps
            //Try Catch used to validate that the user is entering an integer
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input: " + e.Message);
                    Console.ResetColor();
                }
            }

            //Validate user input using ValidateInt() method and store in numOfSteps variable

            //Create new List of type Steps of size numOfSteps
            List<Steps> stepsList = new List<Steps>();

            //Loop used to instantiate each index of the list with a new object of type Steps
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
                #endregion Steps
            }
            //After all ingredients and steps have been entered the ingredients List,
            //steps List and recipeName are parsed to the Recipes class using the object of the recipe class
            //named recipe
            Recipe recipe = new Recipe(recipeName, ingredientsList, stepsList);

            //the Recipe object recipe is then parsed to the RecipeList class using the object
            //of the RecipeList class named recipeList
            RecipeList recipeList = new RecipeList(recipe);
        }

        //Method used to store Try Catch used to validate that the user is entering an integer
        //for better coding practice
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input.\nPlease enter the integer associated with your option of choice.");
                    Console.ResetColor();
                }
            }
            // return validated input
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Please enter a value of type double: ");
                Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Please enter a string: ");
                Console.ResetColor();
                input = Console.ReadLine();
            }
            Console.WriteLine("Captured value : {0}\n", input);
            return input;
        }
    }
}
