// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

using System.Windows;
using System.Windows.Controls;


namespace RecipeAppGUI
{
    /// <summary>
    /// Interaction logic for ScaleRecipeWindow.xaml
    /// </summary>
    public partial class ScaleRecipeWindow : Window
    {
        public double Factor { get; private set; }

        public ScaleRecipeWindow()
        {
            InitializeComponent();
        }

        //display scale factors to user and store chosen factor in double Factor
        private void ScalingFactorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (double.TryParse(button.Content.ToString(), out double factor))
            {
                Factor = factor;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a valid scaling factor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
