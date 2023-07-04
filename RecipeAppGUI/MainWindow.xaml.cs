// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using RecipeApp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RecipeAppGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //collection used to hold all recipes
        private ObservableCollection<Recipe> recipes;
        public MainWindow()
        {
            InitializeComponent();

            recipes = new ObservableCollection<Recipe>();
            //instantiate datagrid with recipes and their details
            recipesDataGrid.ItemsSource = recipes;

            
        }

        
        //Open the add recipe window and sorts the recipeDataGrid alphabetically by recipe Name when the add recipe window is closed
        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow recipeWindow = new RecipeWindow();
            recipeWindow.Owner = this;
            recipeWindow.ShowDialog();

            if (recipeWindow.DialogResult == true)
            {
                recipes.Add(recipeWindow.Recipe);

                ICollectionView view = CollectionViewSource.GetDefaultView(recipesDataGrid.ItemsSource);

                if (view != null)
                {
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                    view.Refresh();
                }
            }
        }

        //only show recipes that include the user entered ingredient name
        private void FilterByIngredientNameButton_Click(object sender, RoutedEventArgs e)
        {
            //user entered ingredient name
            string ingredientName = ingredientNameTextBox.Text;

            //look through recipe list to find a recipe that matches the user entered ingredient name
            var filteredRecipes = from recipe in recipes
                                  where recipe.Ingredients.Any(ingredient => ingredient.Name.Contains(ingredientName))
                                  select recipe;

            //update the datagrid to only show the recipe that contains the user entered ingredient name
            recipesDataGrid.ItemsSource = filteredRecipes;

        }

        //only show recipes that include the user selected Food Group 
        private void FilterByFoodGroupButton_Click(object sender, RoutedEventArgs e)
        {
            //user selected food group
            string foodGroup = (foodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            //look through recipe list to find a recipe that matches the user selected food group
            var filteredRecipes = from recipe in recipes
                                  where recipe.Ingredients.Any(ingredient => ingredient.FoodGroup == foodGroup)
                                  select recipe;

            //update the datagrid to only show the recipe that contains the user entered food group
            recipesDataGrid.ItemsSource = filteredRecipes;
        }

        //only show calories that are below the max calories slider ticker
        private void FilterByMaxCaloriesButton_Click(object sender, RoutedEventArgs e)
        {
            //slider ticker position value
            int maxCalories = (int)maxCaloriesSlider.Value;

            var filteredRecipes = from recipe in recipes
                                  where recipe.Calories <= maxCalories
                                  select recipe;
            //only show recipes that have a total calories less than the value of the position of the slider ticker
            recipesDataGrid.ItemsSource = filteredRecipes;
        }


        //clear all recipe filters
        private void ClearFilterButton_Click(object sender, RoutedEventArgs e)
        {
            //reset all data grids
            recipesDataGrid.ItemsSource = recipes;
            ingredientsDataGrid.ItemsSource = null;
            stepsDataGrid.ItemsSource = null;
        }

        //close program
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        //open scale window and allow user to choose a scale factor to scale the recipe ingredient quantities by
        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            //get the selected recipe
            Recipe selectedRecipe = recipesDataGrid.SelectedItem as Recipe;
            
            //make sure a recipe is selected or return
            if (selectedRecipe == null)
            {
                MessageBox.Show("Please select a recipe to scale.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //open scale window
            ScaleRecipeWindow scaleRecipeWindow = new ScaleRecipeWindow();
            scaleRecipeWindow.Owner = this;
            scaleRecipeWindow.ShowDialog();

            
            if (scaleRecipeWindow.DialogResult == true)
            {
                double factor = scaleRecipeWindow.Factor;

                if (factor == 0.5 || factor == 2 || factor == 3)
                {
                    //call the scale method and pass the user selected scale factor
                    selectedRecipe.Scale(factor);
                    ingredientsDataGrid.ItemsSource = selectedRecipe.Ingredients;
                    ingredientsDataGrid.Items.Refresh();
                }
                else
                {
                    //must choose a scale factor
                    MessageBox.Show("Please select a valid scaling factor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        //reset ingredient quantities to original values
        private void ResetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            //get selected recipe
            Recipe selectedRecipe = recipesDataGrid.SelectedItem as Recipe;

            if (selectedRecipe == null)
            {
                MessageBox.Show("Please select a recipe to reset the quantities.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (Ingredient ingredient in selectedRecipe.Ingredients)
            {
                //for each ingredient in the ingredient list reset the ingredient quantity to the original value
                ingredient.ResetQuantity();
            }

            //update the data grid with the reset quantities
            ingredientsDataGrid.ItemsSource = selectedRecipe.Ingredients;
            ingredientsDataGrid.Items.Refresh();
        }

        //display the ingredient and steps for a selected recipe
        private void ViewRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            //get selected recipe
            Recipe selectedRecipe = recipesDataGrid.SelectedItem as Recipe;

            if (selectedRecipe == null)
            {
                MessageBox.Show("Please select a recipe to scale.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //populate the ingredients and steps datagrids with the selected recipe ingredient and step details
            ingredientsDataGrid.ItemsSource = selectedRecipe.Ingredients;
            stepsDataGrid.ItemsSource = selectedRecipe.Steps;
            ingredientsDataGrid.Items.Refresh();

        }

        //delete the selected recipe from the recipe collection
        private void DeleteRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            //get selected recipe
            Recipe selectedRecipe = recipesDataGrid.SelectedItem as Recipe;

            if (selectedRecipe != null)
            {
                //ask for user confirmation
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the recipe '{selectedRecipe.Name}'?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    //remove recipe from collection
                    recipes.Remove(selectedRecipe);
                    //reset data grids
                    ingredientsDataGrid.ItemsSource = null;
                    stepsDataGrid.ItemsSource = null;
                    recipesDataGrid.ItemsSource = recipes;
                }
            }
        }
    }
}