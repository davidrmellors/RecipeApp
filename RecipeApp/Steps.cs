using System;
namespace RecipeApp
{
	public class Steps
	{
		public string Step;

		public Steps(string step)
		{
			Step = step;
		}

		public string toString()
		{
			string output = string.Format("{0}",Step);
			return output;
		}
	}
}

