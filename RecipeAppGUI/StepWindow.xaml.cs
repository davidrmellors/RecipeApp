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
    /// Interaction logic for StepWindow.xaml
    /// </summary>
    public partial class StepWindow : Window
    {
        public Step Step { get; set; }

        public StepWindow()
        {
            InitializeComponent();

            Step = new Step();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Please enter a description for the step.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Step.Description = descriptionTextBox.Text;

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


    }
}
