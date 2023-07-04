// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{//No Longer In Use
    /*public class RecipeList
    {
        static List<Recipe> recipeList = new List<Recipe>();

        //Constructor takes object of Recipe class and stores in recipeList
        public RecipeList(Recipe recipe)
        {
            recipeList.Add(recipe);
        }

        //Method used to display all recipe names and then display desired recipe details
        public static void ListRecipes()
        {
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("     Recipes    ");
            Console.WriteLine("-----------------\n");

            if (recipeList.Count > 0)
            {
                // sort recipeList by recipeName in alphabetical order
                recipeList = recipeList.OrderBy(r => r.recipeName).ToList();

                //for each recipe in the recipe list output the recipe name
                foreach (Recipe recipe in recipeList)
                {
                    Console.WriteLine("* " + recipe.recipeName);
                }
                //menu to ask user whether they want to display a recipe or exit
                Console.WriteLine("---------------");
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Display a recipe's details");
                Console.WriteLine("2. Exit");

                int input = InputHandler.ValidateInt();


                if (input == 1)
                {

                    Console.Write("\nPlease enter the name of the recipe" +
                            "\nyou would like to display >> ");

                    string recipeName = Console.ReadLine();

                    //for each recipe in recipeList output all recipe details
                    foreach (Recipe recipe in recipeList)
                    {
                        if (recipeName.Equals(recipe.recipeName))
                        {
                            Console.Clear();
                            Console.WriteLine("-----------------");
                            Console.WriteLine("     {0}    ", recipeName);
                            Console.WriteLine("-----------------\n");
                            //Console.WriteLine(recipe.toString());
                        }
                    }
                    Console.WriteLine("--------------------");
                }

            }
            else
            {
                //if no recipes have been captured output this message to console
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Recipes have been captured!");
                Console.ResetColor();
            }
            Console.Write("\nPress any key to continue >> ");
            Console.ReadLine();
        }


        //Method used to ask user by which value they want to scale their recipe quantity by
        //value then used when caling the Scale method from Ingredients class
        public static void ScaleRecipe()
        {
            //Clears the console window to de-clutter console output
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("  Scale Recipe  ");
            Console.WriteLine("-----------------\n");

            Console.WriteLine("[List of Recipes]\n");  
  
            //If recipeList is not empty then display the recipe details
            if (recipeList.Count > 0)
            {
                // sort recipeList by recipeName in alphabetical order
                recipeList = recipeList.OrderBy(r => r.recipeName).ToList();

                //List all recipes
                foreach (Recipe recipe in recipeList)
                {
                    Console.WriteLine("* " + recipe.recipeName);
                }

                Console.Write("\nPlease enter the name of the " +
                            "\nrecipe you would like to scale " +
                            "\nor type [1] to exit >> ");

            string input = InputHandler.NotNull(Console.ReadLine());

            if (!input.Equals("1"))
            {
                foreach (Recipe recipe in recipeList)
                {
                    if (recipe.recipeName.Equals(input))
                    {
                        Console.WriteLine("Recipe Found!\n");

                        Console.WriteLine("Choose an option:");
                        Console.WriteLine("1. Scale recipe by 0.5");
                        Console.WriteLine("2. Scale recipe by 2");
                        Console.WriteLine("3. Scale recipe by 3");
                        Console.WriteLine("4. Exit");

                        int option = 0;
                        bool isValid = false;
                        while (!isValid)
                        {
                            Console.Write(">> ");
                            try
                            {
                                option = int.Parse(Console.ReadLine());
                                if (option > 0 && option < 5)
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

                        double scale = 1;

                        if (option != 4)
                        {
                            switch (option)
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
                                default:
                                    break;
                            }

                            foreach (Ingredients ingredient in recipe.ingredientsList)
                            {
                                ingredient.Scale(scale);
                            }
                            Console.WriteLine("Scaling Complete.");
                        }

                    }
                }
            }

            }
            else
            {
                //if no recipes have been captured output this message to console
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Recipes have been captured!");
                Console.ResetColor();
            }
            Console.Write("\nPress any key to continue >> ");
            Console.ReadLine();
        }

        //Takes original quantities of ingredients and replaces the new quantity
        public static void ResetRecipe()
        {
            //Clears the console window to de-clutter console output
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("   Reset Recipe  ");
            Console.WriteLine("-----------------\n");

            Console.WriteLine("[List of Recipes]\n");
            //If recipeList is not empty then display the recipe details
            if (recipeList.Count() > 0)
            {
                // sort recipeList by recipeName in alphabetical order
                recipeList = recipeList.OrderBy(r => r.recipeName).ToList();

                //List all recipes
                foreach (Recipe recipe in recipeList)
                {
                    Console.WriteLine("* " + recipe.recipeName);
                }

                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Reset quantities to original values");
                Console.WriteLine("2. Exit");

                int input = InputHandler.ValidateInt();

                //as long as the user does not select option 2 from the menu
                //the ingredient quantities will be reset
                if (input == 1)
                {
                    Console.Write("Please enter the name of the " +
                                "\nrecipe you would like to reset " +
                                "\nor type [1] to exit >> ");

                    string resetName = InputHandler.NotNull(Console.ReadLine());

                    if (!resetName.Equals("1"))
                    {
                        foreach (Recipe recipe in recipeList)
                        {
                            if (recipe.recipeName.Equals(resetName))
                            {
                                Console.WriteLine("Recipe Found!");
                                foreach (Ingredients ingredients in recipe.ingredientsList)
                                {
                                    ingredients.ResetRecipe();
                                }
                                Console.WriteLine("Recipe successfully reset.");
                            }
                        }
                    }
                }

            }
            else
            {
                //if no recipes have been captured output this message to console
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Recipes have been captured!");
                Console.ResetColor();
            }
            Console.Write("\nPress and key to continue >> ");
            Console.ReadLine();
        }

        //Method used to empty the recipeList List
        public static void ClearRecipe()
        {
            //Clears the console window to de-clutter console output
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("Clear All Recipes  ");
            Console.WriteLine("-----------------\n");

            if (recipeList.Count() > 0)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Clear all data");
                Console.WriteLine("2. Exit");

                int input = InputHandler.ValidateInt();

                //as long as the user does not select option 2 from the menu
                //the ingredient quantities will be reset
                if (input == 1)
                {
                    Console.WriteLine("Are you sure you want to clear all data?");
                    Console.Write("Type [yes] or [no] >> ");

                    string confirm = InputHandler.NotNull(Console.ReadLine());
                    //if user confirms that they want to clear all data then
                    //the recipeList will be cleared to default(Recipe)
                    if (confirm.Equals("yes"))
                    {
                        recipeList.Clear();
                        Console.WriteLine("All recipe data has been cleared.");
                    }
                }
            }
            else
            {
                //if no recipes have been captured output this message to console
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Recipes have been captured!");
                Console.ResetColor();
            }
            Console.Write("\nPress and key to continue >> ");
            Console.ReadLine();
        }
    }*/
}
