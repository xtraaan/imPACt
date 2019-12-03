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
    public partial class EventsFormPage : ContentPage
    {
        public EventsFormPage()
        {
            InitializeComponent();

        }

        

        private async void CreateButton(object sender, EventArgs e)
        {
            var Event1 = new Events()
            {
                Title = eventName.Text,
                Description = descriptionName.Text,
                Owner = App.currentUser.FirstName
            };

            await App.Database.SaveEventAsync(Event1);
            
            await Navigation.PopAsync();
        }

        private async void CancelButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
