# ST10241455 PROG6221 POE PART 1
[Github Repo](https://github.com/VCCT-PROG6221-2023-Grp3/DavidMellors-ST10241466-PROG6221POE-Part1)

## 1. About the project

This is a standalone command line application written in C# that allows users to enter the details for an unlimited number of recipes, display a full recipe, scale the recipe by a factor of 0.5, 2, or 3, reset recipes to the original values, and clear all the data to enter a new recipe. The data is only stored in memory while the software is running.


## 2. Hardware Requirements
The minimum hardware requirements provided by Microsoft for running applications on the .NET Framework v4.7.2 are as follows:

Processor - 1GHz

RAM - 512MB

Minimum Disk Space (32-bit & 64-bit) - 4.5GB

## 3. Getting Started
### 3.1 To compile and run the application, follow these steps:

1. Clone the repository to your local machine.  
2. Open the project in Visual Studio.  
3. Build the solution.  
4. Start the application by running the RecipeApp executable.

### 3.2 Usage
Once the application is running, you can enter the details for a recipe by following the prompts.  
You will need to enter the number of ingredients, the name, quantity, and unit of measurement for  
each ingredient, the number of steps, and a description of what the user should do for each step.

After you have entered the details for a recipe, you can display the full recipe by selecting the  
"Display Recipe" option from the menu. You can also scale the recipe by a factor of 0.5, 2, or 3 by  
selecting the "Scale Recipe" option and entering the desired factor. To reset the recipe to the  
original values, select the "Reset Recipe" option. To clear all the data and enter a new recipe,  
select the "New Recipe" option.

## 4. Updates

4.1 Added functionality for user to capture an unlimited number of recipes  
4.2 The user may now enter a name for each recipe  
4.3 Users can now list the names of all recipes sorted in alphabetical order  
4.4 Users can now choose which recipes to display from a list  
4.5 For each ingredient a user may now capture the number of calories and the food group the ingredient belongs to  
4.6 The total calories of a recipe will now be displayed  
4.7 When a recipe exceeds 300 calories the user will be alerted  
4.8 Errors are now displayed in red text  
4.9 The user is now given an explanation of what calories are  
4.10 The user is now given an explanation of what a food group is  

## 5. Changes implemented thanks to Mr. Chikoo's feedback

After reading the feedback provided by Mr. Chikoo I have since implemented improvements to each section as listed:

#### Repository management: 
- I have made more frequent commits to github.

#### App Functionality: 
- Users are now informed of the datatype required for  
the input required to avoid confusion. 
- I have also improved the  
structure of my Console Outputs.

#### Coding standards
- I have included regions within my code.

#### Documentation
- I have added more detail to my README file.                               

## 6. References
Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in  
programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

## 7. License

[MIT](https://choosealicense.com/licenses/mit/)