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
        List<Ingredients> ingredientsList = new List<Ingredients>();
        public IngredientsWindow()
        {
            InitializeComponent();
           
        }

        


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

            ErrorStackPanel.Visibility = Visibility.Hidden;

            

            string ingredientName, ingredientUnitOfMeasure, ingredientFoodGroup;
            double ingredientQuantity = 0;
            int ingredientCalories;

            if(IngredientNameTextBox.Text.Length == 0 || IngredientUnitOfMeasureTextBox.Text.Length == 0 || IngredientQuantityTextBox.Text.Length == 0 ||
                TotalCaloriesTextBox.Text.Length == 0 || FoodGroupComboBox.Text.Length == 0)
            {
                
                ErrorLabel.Content = "All fields are required";
                ErrorStackPanel.Visibility= Visibility.Visible;
                return;
            }

            ingredientName = IngredientNameTextBox.Text.ToString();
            ingredientUnitOfMeasure = IngredientUnitOfMeasureTextBox.Text.ToString();
            ingredientFoodGroup = FoodGroupComboBox.SelectedItem.ToString();

            if(ValidateDouble(IngredientQuantityTextBox.Text) == true)
            {
                ingredientQuantity = double.Parse(IngredientQuantityTextBox.Text);
            }
            else
            {
                ErrorLabel.Content = "Please enter a value of type double for ingredient quantity";
                ErrorStackPanel.Visibility = Visibility.Visible;
                return;
            }


            if(ValidateInt(TotalCaloriesTextBox.Text) == true)
            {
                ingredientCalories = int.Parse(TotalCaloriesTextBox.Text);
            }
            else
            {
                ErrorLabel.Content = "Please enter a value of type int for total calories";
                ErrorStackPanel.Visibility = Visibility.Visible;
                return;
            }

            ingredientsList.Add(new Ingredients(ingredientName, ingredientQuantity, ingredientUnitOfMeasure,
            ingredientCalories, ingredientFoodGroup));

            IngredientNameTextBox.Clear();
            IngredientQuantityTextBox.Clear();
            IngredientUnitOfMeasureTextBox.Clear();
            TotalCaloriesTextBox.Clear();
            FoodGroupComboBox.SelectedItem = "";

            IngredientMessageDialog dialog = new IngredientMessageDialog();

            dialog.ShowDialog();
            
        }

        public bool ValidateDouble(string num)
        {
            bool c = double.TryParse(num, out _);

            return c;
        }

        public bool ValidateInt(string num)
        {
            bool c = int.TryParse(num, out _);

            return c;
        }





        private void CloseErrorButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorStackPanel.Visibility = Visibility.Hidden;
        }
    }
}
