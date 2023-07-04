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
    /// Interaction logic for IngredientWindow.xaml
    /// </summary>
    public partial class IngredientWindow : Window
    {
        public Ingredient ingredient { get; set; }
        public IngredientWindow()
        {
            InitializeComponent();

            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please enter a name for the ingredient.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(quantityTextBox.Text, out double quantity))
            {
                MessageBox.Show("Please enter a valid quantity for the ingredient.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(unitTextBox.Text))
            {
                MessageBox.Show("Please enter a unit for the ingredient.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(caloriesTextBox.Text, out int calories))
            {
                MessageBox.Show("Please enter a valid number of calories for the ingredient.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (foodGroupComboBox.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("Please select a food group for the ingredient.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string name = nameTextBox.Text;
            string unit = unitTextBox.Text;
            string foodGroup = foodGroupComboBox.Text;

            ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
