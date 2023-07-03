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
    /// Interaction logic for StepsWindow.xaml
    /// </summary>
    public partial class StepsWindow : Window
    {

        public StepsWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorStackPanel.Visibility = Visibility.Hidden;
            if(StepsTextBox.Text.Length == 0)
            {
                ErrorLabel.Content = "TextBlock must not be empty";
                ErrorStackPanel.Visibility = Visibility.Visible;
                return;
            }

            string step = StepsTextBox.Text.ToString() ;
            
            
            MainWindow.stepsList.Add(new Steps(step)) ;

            this.Close() ;
            AddRecipe addRecipe = new AddRecipe();
            addRecipe.Show() ;
            
        }

        private void CloseErrorButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorStackPanel.Visibility = Visibility.Hidden;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecipe addRecipe = new AddRecipe();
            this.Close();
            addRecipe.Show();
        }
    }
}
