using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace imPACt
{
    public partial class SettingsPage : ContentPage
    {
        string Mjr, Yr, RsrchInt;
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

            Mjr = Major.Items[Major.SelectedIndex];

            //DisplayAlert("Selection", Maj, "Ok");

        }
        private void ResearchInterests_SelectedIndexChanged(object sender, EventArgs e)
        {
            RsrchInt = ResearchInterests.Items[ResearchInterests.SelectedIndex];

            // DisplayAlert("Selection", Res, "Ok");
        }

        private void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Yr = Year.Items[Year.SelectedIndex];
            //    DisplayAlert("Selection", Yr, "Ok");

        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            App.currentUser.FirstName = FirstnameEntry.Text;
            App.currentUser.LastName = LastnameEntry.Text;
            App.currentUser.Major = Mjr;
            App.currentUser.Year = Yr;
            App.currentUser.FirstName = RsrchInt;

            await App.Database.UpdateUser();
            await DisplayAlert("Saved", "Settings Saved", "Ok");

        }
    }
}
