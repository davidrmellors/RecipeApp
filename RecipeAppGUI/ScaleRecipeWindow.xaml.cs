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
    /// Interaction logic for ScaleRecipeWindow.xaml
    /// </summary>
    public partial class ScaleRecipeWindow : Window
    {
        public double Factor { get; private set; }

        public ScaleRecipeWindow()
        {
            InitializeComponent();
        }

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
