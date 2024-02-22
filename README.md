# ST10241455 PROG6221 Portfolio of Evidence
[Github Repo](https://github.com/VCCT-PROG6221-2023-Grp3/DavidMellors-ST10241466-PROG6221POE-Part1)

## 1. About the project

This is a .NET Framework Windows Presentation Foundation application that allows users to enter the details for an unlimited number of recipes, display a full recipe, scale the recipe by a factor of 0.5, 2, or 3, reset recipes to the original values, and clear all the data to enter a new recipe. The data is only stored in memory while the software is running.


## 2. Hardware Requirements
The minimum hardware requirements provided by Microsoft for running applications on the .NET Framework v4.7.2 are as follows:

Processor - 1GHz

RAM - 512MB

Minimum Disk Space (32-bit & 64-bit) - 4.5GB

## 3. Getting Started
### 3.1 To install the application, follow these steps:

To install the application, we must first navigate to the GitHub repository which contains all the necessary source files for the Recipe App. 
To locate the GitHub repository click the GitHub Repo hyperlink at the top of the README.
Once you have opened the link click the bright green code button in the top right and then click “Download as ZIP”.
Once the ZIP folder has downloaded, unzip it to a safe location.

### 3.2 To run the Recipe App in Visual Studio, follow these steps:

Open Visual Studio and select "Open a project or solution" from the start page.
Navigate to the location where you unzipped the Recipe App project open the folder and select the solution file (RecipeApp.sln).
Once the project is loaded, select "Build" from the menu bar and then select "Build Solution" to build the project.
After the project is built successfully, select "Debug" from the menu bar and then select "Start Debugging" to run the app.



### 3.3 Usage
please refer to the User Manual to learn how to use the RecipeApp

## 4. Updates

### PART 1 Updates
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

### Part 2 Updates

4.11 WPF has now been used to create a graphical user interface for the recipe app
4.12 The solution has a new proect named RecipeAppGUI
4.13 Within RecipeAppGUI the following windows have been added:
IngredientWindow, used to input ingredient data.
MainWindow used as the home page of the RecipeAppGUI, displays a table of recipes, ingredients and steps with functionality to Add a Recipe, View a Recipe, Scale a Recipe, Reset a Recipe, Delete a Recipe and Filter Recipes.
RecipeWindow, used to add Recipe name, Recipe ingredients and Recipe steps.
ScaleRecipeWindow used to allow the user to choose a scale factor to scale their recipe ingredients by.
StepWindow used to add steps to the recipe.
4.14 The can now filter the list of recipes by: entering the name of an ingredient that must be in the recipe, choosing a food group that must be in the recipe, or selecting a maximum number of calories
4.15  A UserManual has been created to guide a user on how to use the RecipeApp

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

#### App Functionality: The user can enter unlimited recipes each with a name.                          
Users can now just click add to add a new recipe, step, or ingredient.

## 6. Changes implemented thanks to Mr. Chikoo's Part 2 feedback

After reading the feedback provided by Mr. Chikoo for my Part 2 submission I have since implemented improvements to each section as listed:

#### App Functionality: The user can enter unlimited recipes each with a name.                          
Users can now just click add to add a new recipe, step, or ingredient.

#### App Functionality: The app displays the list of recipes in alphabetical order
The list of recipes is displayed in alphabetical order and the user can select to display a recipes details

#### Application Structure:  The recipes, ingredients and steps are stored in  generic collections.
The user is not prompted for how many recipes, steps or ingredients they would like to add, instead they can just click add until they are finished.

#### Documentation: Readme file provides enough information to run the app.
I have included a more in depth tutorial on how to Get Started with the Recipe App.

## 7. References
Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in  
programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

## 8. License

[MIT](https://choosealicense.com/licenses/mit/)
