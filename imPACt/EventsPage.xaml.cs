using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace imPACt
{
    public partial class EventsPage : ContentPage
    {
        public EventsPage()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void UpdateButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        //private async void InviteMembersButton(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new EventsLayoutPage());
        //}
    }
}
