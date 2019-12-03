using imPACt.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace imPACt
{
    public partial class AllEventsLayoutPage : ContentPage
    {
        public AllEventsLayoutPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }



        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Remove current user from list
            var users = await App.Database.GetEventAsync();
            List<Events> list = new List<Events>();

            foreach (var ev in users)
            {
                if (ev != null)
                {
                   list.Add(ev);
                }
             }
            
            if (list.Count() != 0)
                listView.ItemsSource = list;
            else
                await DisplayAlert("No Current Events", "Try again later...", "Okay", "Cancel");
        } 







            private async void CreateButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventsFormPage());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventsPage());
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventsFormPage());
        }
    }
}
