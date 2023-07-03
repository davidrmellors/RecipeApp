// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using System;
namespace RecipeApp
{
    //Class used to store all Step details
    public class Steps
    {
        public string Step;
        public int StepNum;

        //string step entered by user is taken as argument and then stored locally
        public Steps(string step)
        {
            Step = step;
        }

        //method used to return step details as string
        public string toString()
        {
            string output = string.Format("{0}", Step);
            return output;
        }
    }
}
