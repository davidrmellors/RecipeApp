using RecipeApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {
        public static string RecipeName;
        public static int NumberOfIngredients;
        public static int NumberOfSteps;
        public AddRecipe()
        {
            InitializeComponent();

            MainWindow.ingredientNamesList.Clear();
            MainWindow.stepsDescList.Clear();

            foreach(Ingredients ingredient in MainWindow.ingredientsList)
            {
                MainWindow.ingredientNamesList.Add(ingredient.IngredientName.ToString());
            }

            foreach(Steps steps in MainWindow.stepsList)
            {
                MainWindow.stepsDescList.Add(steps.Step.ToString());
            }

            IngredientsListBox.ItemsSource = MainWindow.ingredientNamesList;
            StepsListBox.ItemsSource = MainWindow.stepsDescList;
        }




        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        

        private void CloseErrorButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorStackPanel.Visibility = Visibility.Hidden;
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            IngredientsWindow ingredientsWindow = new IngredientsWindow();
            ingredientsWindow.Show();
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            StepsWindow stepsWindow = new StepsWindow();
            stepsWindow.Show();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorStackPanel.Visibility = Visibility.Hidden;

            if(RecipeNameTextBox.Text.Length == 0 || IngredientsListBox.Items.Count == 0 || StepsListBox.Items.Count == 0)
            {
                ErrorLabel.Content = "all fields are required";
                ErrorStackPanel.Visibility= Visibility.Visible;
                return;
            }

            string recipeName = RecipeNameTextBox.Text.ToString();

            Recipe recipe = new Recipe(recipeName, MainWindow.ingredientsList, MainWindow.stepsList);

            MainWindow mainWindow = new MainWindow(recipe);
            this.Close();
            mainWindow.Show();

        }
    }
}
