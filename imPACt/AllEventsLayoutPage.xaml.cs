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
            //Populating event list to display
            foreach (var ev in users)
            {
                if (ev != null)
                {
                   list.Add(ev);
                }
             }
            //As long as event view is not empty then populate listView
            if (list.Count() != 0)
                listView.ItemsSource = list;
            else
                await DisplayAlert("No Current Events", "Try again later...", "Okay", "Cancel");
        } 

        //Adding event button
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventsFormPage());
        }

        //Clicking Item and sending current event to page
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Events;
            await Navigation.PushAsync(new EventsPage(content));
        }
    }
}
