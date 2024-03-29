﻿
using System;
using imPACt.Tables;
using Xamarin.Forms;

namespace imPACt.Matching
{
    
    public partial class ConnectProfilePage : ContentPage
    {
        Friends friend = new Friends();
        public RegisterUserTable ClickedUser;


        public ConnectProfilePage(RegisterUserTable user)
        {

            InitializeComponent();
            ClickedUser = user;
            //NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            //Once appearing fill in Labels needed
            base.OnAppearing();
            name.Text = " " + ClickedUser.FullName;
            researchInterests.Text = " " + ClickedUser.ResearchInterest;
            major.Text = " " + ClickedUser.Major;
            gradeYear.Text = " " + ClickedUser.Year;
            school.Text = " " + ClickedUser.School;
            image.Source = ClickedUser.ImageSource;

        }

        // Needs to be fixed, populate list in Matches
        async void OnConnectClicked(object sender, EventArgs e)
        {
            //storing matched users in friend database table not efficient way of doing it
            friend.userID = App.currentUser.UserId;
            friend.FriendID = ClickedUser.UserId;

            await App.Database.SaveFriendAsync(friend);
            
            await DisplayAlert("Matched!", "Return to Matches", "Okay");
            await this.Navigation.PopAsync();

        }
    }
}

