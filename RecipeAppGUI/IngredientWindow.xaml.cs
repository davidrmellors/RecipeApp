// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using RecipeApp;
using System.Windows;


namespace RecipeAppGUI
{
    /// <summary>
    /// Interaction logic for IngredientWindow.xaml
    /// </summary>
    public partial class IngredientWindow : Window
    {
        //ingredient object used to reference Ingredient class
        public Ingredient ingredient { get; set; }
        public IngredientWindow()
        {
            InitializeComponent();

            
        }
        
        //Adds ingredient to the recipe
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //if ingredient name is left empty
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please enter a name for the ingredient.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //if ingredient quantity is left empty
            if (!double.TryParse(quantityTextBox.Text, out double quantity))
            {
                MessageBox.Show("Please enter a valid quantity for the ingredient.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //if ingredient unit of measurement is left empty
            if (string.IsNullOrWhiteSpace(unitTextBox.Text))
            {
                MessageBox.Show("Please enter a unit for the ingredient.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //if calories is left empty
            if (!int.TryParse(caloriesTextBox.Text, out int calories))
            {
                MessageBox.Show("Please enter a valid number of calories for the ingredient.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //if a food group has not been selected
            if (foodGroupComboBox.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("Please select a food group for the ingredient.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           
            string name = nameTextBox.Text;
            string unit = unitTextBox.Text;
            string foodGroup = foodGroupComboBox.Text;

            //create a new Ingredient object using the user entered details name, quantity, unit, calories, foodGroup.
            ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);

            DialogResult = true;
        }

        //cancels the add ingredient function
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
