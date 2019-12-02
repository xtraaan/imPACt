using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace imPACt
{
    public partial class EventsLayoutPage : ContentPage
    {
        public EventsLayoutPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void CreateButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventsFormPage());
        }
    }
}
