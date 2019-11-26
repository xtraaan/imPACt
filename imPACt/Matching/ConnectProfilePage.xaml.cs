
using System;
using imPACt.Tables;
using Xamarin.Forms;

namespace imPACt.Matching
{
    public partial class ConnectProfilePage : ContentPage
    {
        public RegisterUserTable ClickedUser;
        public ConnectProfilePage(RegisterUserTable user)
        {

            InitializeComponent();
            ClickedUser = user;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            name.Text = ClickedUser.FullName;
            researchInterests.Text = ClickedUser.ResearchInterest;
            major.Text = ClickedUser.Major;
            gradeYear.Text = ClickedUser.Year;

        }

        // Needs to be fixed, populate list in Matches
        async void OnConnectClicked(object sender, EventArgs e)
        {
            App.currentUser.Matches.Add(ClickedUser);
            var users = App.Database.GetMatches();
            string list = string.Join(",", users);
            await DisplayAlert("Matches", list, "Ok");

        }
    }
}

