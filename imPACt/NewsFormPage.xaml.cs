using imPACt.Tables;
using System;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace imPACt
{
    public partial class NewsFormPage : ContentPage
    {
        public NewsFormPage()
        {
            InitializeComponent();
        }

        private async void CreateButton(object sender, EventArgs e)
        {
            var News1 = new News()
            {
                NewsTitle = newsName.Text,
                NewsDescription = newsDescription.Text,
                NewsAuthor = newsAuthor.Text
            };

            await App.Database.SaveNewsAsync(News1);

            await Navigation.PopAsync();
        }

        private async void CancelButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}