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
    /// Interaction logic for IngredientsWindow.xaml
    /// </summary>
    public partial class IngredientsWindow : Window
    {
        public IngredientsWindow()
        {
            InitializeComponent();
           
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecipe addRecipe = new AddRecipe();
            this.Close();
            addRecipe.Show();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorStackPanel.Visibility = Visibility.Hidden;

            InputHandler inputHandler = new InputHandler();

            if (IngredientNameTextBox.Text.Length == 0 || IngredientUnitOfMeasureTextBox.Text.Length == 0 || IngredientQuantityTextBox.Text.Length == 0 ||
            TotalCaloriesTextBox.Text.Length == 0 || FoodGroupComboBox.Text.Length == 0)
            {

                ErrorLabel.Content = "All fields are required";
                ErrorStackPanel.Visibility= Visibility.Visible;
                return;
            }

            if(inputHandler.ValidateDouble(IngredientQuantityTextBox.Text) == false)
            {
                ErrorLabel.Content = "Please enter a value of type double for ingredient quantity";
                ErrorStackPanel.Visibility = Visibility.Visible;
                return;
            }

            if (inputHandler.ValidateInt(TotalCaloriesTextBox.Text) == false)
            {
                ErrorLabel.Content = "Please enter a value of type int for total calories";
                ErrorStackPanel.Visibility = Visibility.Visible;
                return;
            }

            string ingredientName = IngredientNameTextBox.Text.ToString();
            string ingredientUnitOfMeasure = IngredientUnitOfMeasureTextBox.Text.ToString();
            string ingredientFoodGroup = FoodGroupComboBox.SelectedItem.ToString();
            double ingredientQuantity = double.Parse(IngredientQuantityTextBox.Text);
            int ingredientCalories = int.Parse(TotalCaloriesTextBox.Text);

            
            MainWindow.ingredientsList.Add(new Ingredients(ingredientName, ingredientQuantity, ingredientUnitOfMeasure,
            ingredientCalories, ingredientFoodGroup));

            this.Close();
            AddRecipe addRecipe = new AddRecipe();
            addRecipe.Show();
        }

        

        





        private void CloseErrorButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorStackPanel.Visibility = Visibility.Hidden;
        }
    }
}
