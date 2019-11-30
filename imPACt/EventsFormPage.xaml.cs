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

        async void OnCreateEventButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventsPage());
        }
    }
}
