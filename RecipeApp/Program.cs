// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using System;
namespace RecipeApp
{
	public class Program
	{
		public Program()
		{
		}

		public static void Main(String[] args)
		{
			//Creating instance of InputHandler() class named input
			InputHandler input = new InputHandler();

			/*Using "input" object to call UserInput() method used to request
			user input*/
			input.UserInput();
			//Console.ReadLine(); used to keep Console open after all code has been run
			//untill user presses a key.
			Console.ReadLine();
		}
	}
}

