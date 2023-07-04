using RecipeApp;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

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

        private void RemoveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (ingredientsDataGrid.SelectedItem != null)
            {
                Recipe.Ingredients.Remove((Ingredient)ingredientsDataGrid.SelectedItem);
                ingredientsDataGrid.Items.Refresh();
            }
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            StepWindow stepWindow = new StepWindow();
            stepWindow.Owner = this;
            stepWindow.ShowDialog();

            if (stepWindow.DialogResult == true)
            {
                Recipe.AddStep(stepWindow.Step.Description);
                stepsListBox.Items.Refresh();
            }
        }

        private void RemoveStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (stepsListBox.SelectedItem != null)
            {
                Recipe.Steps.Remove((Step)stepsListBox.SelectedItem);
                stepsListBox.Items.Refresh();
            }
        }

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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
