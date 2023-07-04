﻿// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RecipeApp
{
    //Class for storing all recipe details
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public int Calories
        {
            get
            {
                int totalCalories = 0;

                foreach (Ingredient ingredient in Ingredients)
                {
                    totalCalories += ingredient.Calories;
                }

                return totalCalories;
            }
        }

        public int NumOfIngredients
        {
            get
            {
                int numOfIngredients = 0;
                foreach (Ingredient ingredient in Ingredients)
                {
                    numOfIngredients++;
                }

                return numOfIngredients;
            }
        }

        public int NumOfSteps
        {
            get
            {
                int numOfSteps = 0;
                foreach (Step step in Steps)
                {
                    numOfSteps++;
                }
                return numOfSteps;
            }
        }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(string description)
        {
            Steps.Add(new Step { Description = description });
        }

        public void Scale(double factor)
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }


    }
}
