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
			InputHandler input = new();

			input.UserInput();
			Console.ReadLine();
		}
	}
}

