// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.
using RecipeApp;
using System.Windows;


namespace RecipeAppGUI
{
    /// <summary>
    /// Interaction logic for RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Window
    {
        public Recipe Recipe { get; set; }

        public RecipeWindow()
        {
            InitializeComponent();

            Recipe = new Recipe("");
            ingredientsDataGrid.ItemsSource = Recipe.Ingredients;
            stepsListBox.ItemsSource = Recipe.Steps;
        }

        //add a new ingredient to the recipe by opening ingredient window
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            IngredientWindow ingredientWindow = new IngredientWindow();
            ingredientWindow.Owner = this;
            ingredientWindow.ShowDialog();

            if (ingredientWindow.DialogResult == true)
            {
                Recipe.AddIngredient(ingredientWindow.ingredient);
                ingredientsDataGrid.Items.Refresh();
            }
        }

        //remove an ingredient from the recipe
        private void RemoveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (ingredientsDataGrid.SelectedItem != null)
            {
                //remove ingredient from the recipe.ingredients list
                Recipe.Ingredients.Remove((Ingredient)ingredientsDataGrid.SelectedItem);
                //refresh data grid
                ingredientsDataGrid.Items.Refresh();
            }
        }

        //add a new step to the recipe by opening steps window
        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            StepWindow stepWindow = new StepWindow();
            stepWindow.Owner = this;
            stepWindow.ShowDialog();

            if (stepWindow.DialogResult == true)
            {
                //add step to recipe object and refresh step listbox
                Recipe.AddStep(stepWindow.Step.Description);
                stepsListBox.Items.Refresh();
            }
        }

        //remove step from recipe object
        private void RemoveStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (stepsListBox.SelectedItem != null)
            {
                //remove step from recipe object step list
                Recipe.Steps.Remove((Step)stepsListBox.SelectedItem);
                //refresh data grid
                stepsListBox.Items.Refresh();
            }
        }

        //Save recipe and add recipe name to recipe object
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please enter a name for the recipe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Recipe.Name = nameTextBox.Text;

            DialogResult = true;
        }

        //close recipe window
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
