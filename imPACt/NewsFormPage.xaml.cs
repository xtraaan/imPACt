using System;
using System.Collections.Generic;
using imPACt.Tables;
using Xamarin.Forms;

namespace imPACt
{
    public partial class NewsFormPage : ContentPage
    {
		News Article = new News();

		public NewsFormPage()
        {
            InitializeComponent();
        }

		private async void CreateButton(object sender, EventArgs e)
		{

			Article.NewsName = newsName.Text;
			Article.NewsAuthor = authorName.Text;
			Article.NewsDescription = descriptionName.Text;
			
			await App.Database.SaveNewsAsync(Article);
			await Navigation.PopAsync();
		}

		private async void CancelButton(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AllNewsPage());
		}
	}
}
