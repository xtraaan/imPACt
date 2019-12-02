using System;
using System.Collections.Generic;

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
            await Navigation.PushAsync(new EventsPage());
        }

        private async void CancelButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventsLayoutPage());
        }
    }
}
