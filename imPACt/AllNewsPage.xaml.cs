using imPACt.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace imPACt
{
    public partial class AllNewsPage : ContentPage
    {
        public AllNewsPage()
        {
            InitializeComponent();
        }

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			var newsusers = await App.Database.GetNewsAsync();
			List<News> newsList = new List<News>();

			foreach (var ne in newsusers)
			{
				if (ne != null)
				{
					newsList.Add(ne);
				}
			}

			if (newsList.Count() != 0)
				listView.ItemsSource = newsList;
			else
				await DisplayAlert("No Current News", "Try again later...", "Okay", "Cancel");
		}

		private async void CreateButton(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewsFormPage());
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			//await Navigation.PushAsync(new NewsPage());
		}

        private async void ImageButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewsFormPage());
		}
	}
}
