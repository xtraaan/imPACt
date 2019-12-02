using System;
using System.Collections.Generic;

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

        private async void CreateButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventsFormPage());
        }
    }
}
