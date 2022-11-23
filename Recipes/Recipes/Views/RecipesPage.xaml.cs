using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Recipes.Models;
using Recipes;
using Xamarin.Forms;

namespace Recipes.Views
{
    public partial class RecipesPage : ContentPage
    {
        public RecipesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetRecipeAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the RecipesEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(RecipeEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                Recipe recipe = (Recipe)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(RecipeEntryPage)}?{nameof(RecipeEntryPage.ItemId)}={recipe.ID.ToString()}");
            }
        }
    }
}