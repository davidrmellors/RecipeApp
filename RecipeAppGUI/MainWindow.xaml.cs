using RecipeApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeAppGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Recipe> recipes;
        public MainWindow()
        {
            InitializeComponent();

            recipes = new ObservableCollection<Recipe>();
            recipesDataGrid.ItemsSource = recipes;

            
        }

        

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

        private void FilterByIngredientNameButton_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = ingredientNameTextBox.Text;

            var filteredRecipes = from recipe in recipes
                                  where recipe.Ingredients.Any(ingredient => ingredient.Name.Contains(ingredientName))
                                  select recipe;

            recipesDataGrid.ItemsSource = filteredRecipes;

        }

        private void FilterByFoodGroupButton_Click(object sender, RoutedEventArgs e)
        {
            string foodGroup = (foodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            var filteredRecipes = from recipe in recipes
                                  where recipe.Ingredients.Any(ingredient => ingredient.FoodGroup == foodGroup)
                                  select recipe;

            recipesDataGrid.ItemsSource = filteredRecipes;
        }

        private void FilterByMaxCaloriesButton_Click(object sender, RoutedEventArgs e)
        {
            int maxCalories = (int)maxCaloriesSlider.Value;

            var filteredRecipes = from recipe in recipes
                                  where recipe.Calories <= maxCalories
                                  select recipe;

            recipesDataGrid.ItemsSource = filteredRecipes;
        }

        private void ClearFilterButton_Click(object sender, RoutedEventArgs e)
        {
            recipesDataGrid.ItemsSource = recipes;
            ingredientsDataGrid.ItemsSource = null;
            stepsDataGrid.ItemsSource = null;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = recipesDataGrid.SelectedItem as Recipe;

            if (selectedRecipe == null)
            {
                MessageBox.Show("Please select a recipe to scale.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ScaleRecipeWindow scaleRecipeWindow = new ScaleRecipeWindow();
            scaleRecipeWindow.Owner = this;
            scaleRecipeWindow.ShowDialog();

            if (scaleRecipeWindow.DialogResult == true)
            {
                double factor = scaleRecipeWindow.Factor;

                if (factor == 0.5 || factor == 2 || factor == 3)
                {
                    selectedRecipe.Scale(factor);
                    ingredientsDataGrid.ItemsSource = selectedRecipe.Ingredients;
                    ingredientsDataGrid.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Please select a valid scaling factor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ResetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = recipesDataGrid.SelectedItem as Recipe;

            if (selectedRecipe == null)
            {
                MessageBox.Show("Please select a recipe to reset the quantities.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (Ingredient ingredient in selectedRecipe.Ingredients)
            {
                ingredient.ResetQuantity();
            }

            ingredientsDataGrid.ItemsSource = selectedRecipe.Ingredients;
            ingredientsDataGrid.Items.Refresh();
        }

        private void ViewRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = recipesDataGrid.SelectedItem as Recipe;

            if (selectedRecipe == null)
            {
                MessageBox.Show("Please select a recipe to scale.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ingredientsDataGrid.ItemsSource = selectedRecipe.Ingredients;
            stepsDataGrid.ItemsSource = selectedRecipe.Steps;
            ingredientsDataGrid.Items.Refresh();

        }
    }
}