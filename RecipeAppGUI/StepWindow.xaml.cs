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
// Code Attribution
// Troelsen, A. and Japikse, P. (2021). Pro C# 9 with .NET 5 : foundational principles and practices in programming. 10th ed. Berkeley, Ca: Apress L. P., . Copyright.

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

        //set user entered step description to Step object Description
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
