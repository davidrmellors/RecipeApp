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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeAppGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Recipe> recipeList = new ObservableCollection<Recipe>();
        public static ObservableCollection<Ingredients> ingredientsList = new ObservableCollection<Ingredients>();
        public static ObservableCollection<Steps> stepsList = new ObservableCollection<Steps>();
        public static ObservableCollection<string> recipeNamesList = new ObservableCollection<string>();
        public static ObservableCollection<string> ingredientNamesList = new ObservableCollection<string>();
        public static ObservableCollection<string> stepsDescList = new ObservableCollection<string>();

        public MainWindow(ObservableCollection<Recipe> recipes)
        {
            InitializeComponent();

            recipeNamesList.Clear();

            recipeList = recipes;

            foreach(Recipe recipe in recipeList)
            {
                recipeNamesList.Add(recipe.recipeName.ToString());
            }

            RecipeListBox.ItemsSource = recipeNamesList;
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddRecipe addRecipe = new AddRecipe();
            addRecipe.Show();

        }

        public void CheckRecipes()
        {

        }
    }
}
