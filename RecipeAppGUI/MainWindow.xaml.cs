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
using static RecipeAppGUI.MainWindow;

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
        private CollectionViewSource _collectionViewSource;
        public MainWindow(Recipe recipe)
        {
            InitializeComponent();

            recipeNamesList.Clear();
            ingredientsList.Clear();
            stepsList.Clear();


            recipeList.Add(recipe);

            /*foreach(Recipe recipes in recipeList)
            {
                RecipeDataGrid recipeData = new RecipeDataGrid();

                recipeData.RecipeName = recipes.recipeName;
                recipeData.RecipeCalories = recipes.Calories;
                foreach(Ingredients ing in recipes.ingredientsList)
                {
                    recipeData.IngredientName
                }

            }*/
            RecipeDataGrid.ItemsSource = recipeList;

        }

        /*public class RecipeDataGrid
        {
            public string RecipeName { get; set; }
            public double RecipeCalories { get; set; }
            public string IngredientName { get; set; }
            public string IngredientUnitOfMeasure { get; set; }
            public double IngredientQty { get; set; }
            public double IngredientCalories { get; set; }
            public string IngredientFoodGroup { get; set; }
        }*/
        
        public MainWindow() { InitializeComponent(); }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddRecipe addRecipe = new AddRecipe();
            addRecipe.Show();
        }

        public void CheckRecipes()
        {

        }

        private void ViewRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
